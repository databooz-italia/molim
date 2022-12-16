using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using Molim.Backend.API.BusinessLayer.Exceptions;
using Molim.Backend.API.BusinessLayer.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molim.Backend.API.BusinessLayer.Interfaces
{
    public abstract class IManagerRichiesteEsecuzione : BaseService
    {
        #region classes and enums

        public enum StatiRichieste
        {
            ATTESA,
            ESECUZIONE,
            ERRORE,
            COMPLETATO
        }

        #endregion

        public IManagerRichiesteEsecuzione(MolimDb db, Configuration conf, IAuthenticationProvider auth, ILogger logger) : base(db, conf, auth, logger)
        {

        }

        public IManagerRichiesteEsecuzione(BaseService b) : base(b)
        {

        }

        #region protected methods

        /// <summary>
        /// Ritorna l'id dell'esecutore più scarico, ovvero con meno fasi != complete
        /// </summary>
        /// <returns></returns>
        protected virtual string GetIdEsecutore()
        {
            return Database
                .EsecutoriRichieste
                .FirstOrDefault().ID;
                //.Where(x => x.Status != StatiRichieste.COMPLETATO.ToString())
                //.ToList()
                //.GroupBy(x => x.Richiesta.IdEsecutore)
                //.ToDictionary(x => x.ID, y => y.Count());

            //return dictEsecutori.OrderBy(x => x.Value).FirstOrDefault().Key;
        }

        /// <summary>
        /// Imposta la proprità parametri della richiesta secondo le logiche del manager implementato. By default, imposta IManagerRichiesteEsecuzione.ParametriRichiesta.
        /// </summary>
        /// <param name="richiesta"></param>
        protected abstract Task<string> InitializeParametriRichiesta(RichiestaEsecuzione richiesta);       

        protected virtual T Deserialize<T>(string parametri)
        {
            if (parametri == null)
                return default(T);

            return JsonConvert.DeserializeObject<T>(parametri);
        }

        protected virtual string Serialize<T>(T parametri)
        {
            if (parametri == null)
                return null;

            return JsonConvert.SerializeObject(parametri);
        }

        /// <summary>
        /// Popola le fasi nell'entità passata in ingresso e le persiste sul db
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected abstract void InitializeFasiRichiestaEsecuzioni(RichiestaEsecuzione richiesta);

        protected abstract Task RunFaseRichiestaEsecuzione(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase);

        #endregion

        public async Task<bool> ExecuteRichieste(string idExecutor)
        {
            bool totalSuccess = true;

            var richieste = Database
                .RichiesteEsecuzione
                .Where(x => !x.DataCompletamento.HasValue)
                .OrderByDescending(x => x.Data)
                .Take(1)
                .ToList();

            foreach (RichiestaEsecuzione richiesta in richieste)
            {
                _logger.LogInformation($"Retrieving request {richiesta.ID} data");

                richiesta.Paziente = Database.Pazienti.AsNoTracking().SingleOrDefault(x => x.IdPaziente == richiesta.IdPaziente);
                richiesta.Paziente.Esami = Database.Esami.AsNoTracking().Where(x => x.IdPaziente == richiesta.IdPaziente).ToList();

                foreach (var esame in richiesta.Paziente.Esami)
                    esame.FeaturesEsame = Database.FeaturesEsame.AsNoTracking().Where(x => x.IdEsame == esame.IdEsame).ToList();

                richiesta.Algoritmo = Database.Algoritmi.AsNoTracking().SingleOrDefault(x => x.Id == richiesta.IdAlgoritmo);
                richiesta.Algoritmo.Features = Database.FeaturesAlgoritmi.AsNoTracking().Where(x => x.IdAlgoritmo == richiesta.IdAlgoritmo).ToList();

                foreach (var algFeat in richiesta.Algoritmo.Features)
                    algFeat.Feature = Database.Features.AsNoTracking().SingleOrDefault(x => x.Id == algFeat.IdFeature);

                _logger.LogInformation($"Starting request {richiesta.ID} execution");

                bool failure = false;

                var fasi = Database
                    .RichiestaEsecuzioneFasi
                    .Where(x => x.Status != StatiRichieste.COMPLETATO.ToString())
                    .OrderBy(x => x.Ordine).ThenBy(x => x.IdFase)
                    .ToList();

                var ordini = fasi.Select(x => x.Ordine).Distinct().OrderBy(x => x);

                //Per ogni numero ordine (es. 1, 2, 2, 3, 4) eseguo tutte le fasi nell'ordine, senza considerare fallimenti
                foreach (var ordine in ordini)
                {
                    foreach (var fase in fasi.Where(x => x.Ordine == ordine))
                    {
                        _logger.LogInformation($"exeucting request {richiesta.ID} phase {fase.IdFase}");

                        fase.DataUltimaEsecuzione = DateTime.Now;

                        try
                        {
                            await RunFaseRichiestaEsecuzione(richiesta, fase);
                            fase.Status = StatiRichieste.COMPLETATO.ToString();

                            _logger.LogInformation($"exeuction of request {richiesta.ID} phase {fase.IdFase} successful");
                        }
                        catch (Exception ex)
                        {
                            failure |= true;
                            fase.Status = StatiRichieste.ERRORE.ToString();

                            _logger.LogError(ex, $"Error during exeuction of request {richiesta.ID} phase {fase.IdFase}");
                        }
                    }

                    //Se l'ordine fallisce, non vado avanti alle prossime fasi
                    if (failure)
                    {
                        _logger.LogError($"Exit from exeuction of request {richiesta.ID} for failures");
                        totalSuccess = false;

                        break;
                    }
                }

                

                //Se non ci sono stati fallimenti, imposto come complete la richiesta
                if (!failure)
                {
                    richiesta.DataCompletamento = DateTime.Now;

                    Database.Predizioni.Add(new Predizione()
                    {
                        DataStato = DateTime.Now,
                        Esito = richiesta.Risultato,
                        IdAlgoritmo = richiesta.IdAlgoritmo,
                        IdPatologia = richiesta.IdPatologia,
                        IdPaziente = richiesta.IdPaziente,
                        Stato = "Completata",
                        CreationDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now
                    });
                }

                richiesta.Paziente = null;
                richiesta.Algoritmo = null;

                Database.SaveChanges();
            }

            return totalSuccess;
        }

        public async Task<RichiestaEsecuzione> CreateRichiestaEsecuzione(int idAlgoritmo, string idPaziente, int? idImmagine, int? idRegioneDiInteresse, string IdPatologia)
        {
            _logger.LogInformation("Requesting creazione richiesta esecuzione algoritmo {0} per {1} con tipo esame {2} patologia {3}");

            if (!CheckPermissionBase(Permissions.ReadPazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            if (idAlgoritmo < 0 || string.IsNullOrEmpty(idPaziente) || string.IsNullOrEmpty(IdPatologia) || idImmagine < 0)
                throw new BusinessManagedException(ErrorCodes.BadRequest.ToString());

            if (idRegioneDiInteresse.HasValue)
                idImmagine = Database.RegioniDiInteresse.SingleOrDefault(x => x.Id == idRegioneDiInteresse.Value)?.IdImmagine;

            if(!idImmagine.HasValue)
                throw new BusinessManagedException(ErrorCodes.BadRequest.ToString());

            //Database.Database.ExecuteSqlRaw("DELETE FROM richiesteesecuzione WHERE DataCompletamento IS NULL;");

            var idEsecutore = GetIdEsecutore();

            var richiestaEsecuzione = new RichiestaEsecuzione()
            {
                IdAlgoritmo = idAlgoritmo,
                IdPaziente = idPaziente,
                IdImmagine = idImmagine.Value,
                IdRegioneDiInteresse = idRegioneDiInteresse,
                IdPatologia = IdPatologia,
                IdEsecutore = idEsecutore,
                Data = DateTime.Now
            };

            richiestaEsecuzione.Algoritmo = Database.Algoritmi.AsNoTracking().SingleOrDefault(x => x.Id == richiestaEsecuzione.IdAlgoritmo);

            richiestaEsecuzione.Parametri = await InitializeParametriRichiesta(richiestaEsecuzione);
            InitializeFasiRichiestaEsecuzioni(richiestaEsecuzione);

            richiestaEsecuzione.Algoritmo = null;

            var entity = Database.RichiesteEsecuzione.Add(richiestaEsecuzione);

            Database.SaveChanges();

            //TODO - SOLO SE ALGORITMO SYNC
            //if(algoritmo.Sincrono)
            //{
            bool success = await ExecuteRichieste(idEsecutore);
            //}
            Database.SaveChanges();            

            return richiestaEsecuzione;
        }
    }
}
