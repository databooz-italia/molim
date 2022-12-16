using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Molim.Backend.API.Utils.Cryptography;
using Molim.Backend.API.BusinessLayer.Interfaces;
using Molim.Backend.API.BusinessLayer.Data.Queries.Accounts;
using Molim.Backend.API.BusinessLayer.Services.Pazienti.Models;

namespace Molim.Backend.API.BusinessLayer.Services.Authentication
{
    public class PazientiService : BaseService
    {

        public PazientiService(MolimDb db, Configuration conf, IAuthenticationProvider auth, ILogger logger) : base(db, conf, auth, logger)
        {

        }

        public PazientiService(BaseService b) : base(b)
        {

        }

        public IEnumerable<PazienteProxy> GetPazienti()
        {
            _logger.LogInformation("Requesting pazienti");

            if (!CheckPermissionBase(Permissions.ReadPazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            return Database
                .GetPazienti()
                .Select(x => new PazienteProxy()
                {
                    IdPaziente = x.IdPaziente,
                    AnnoNascita = x.AnnoNascita,
                    City = x.City,
                    CodiceFiscale = x.CodiceFiscale,
                    CognomePaziente = x.CognomePaziente,
                    NomePaziente = x.NomePaziente,
                    NumeroCellulare = x.NumeroCellulare,
                    Sesso = x.Sesso,
                    Education = x.Education,
                    Indirizzo = x.Indirizzo,
                    IndirizzoMail = x.IndirizzoMail
                })
                .ToList();
        }

        public Paziente CreatePaziente(string id, string city, string codiceFiscale, string cognome, string nome, string numeroCellulare, string sesso, int? education, string indirizzo, string indirizzoMail, int? annoNascita)
        {
            _logger.LogInformation("Creating paziente id {0} - {1} {2}", id, cognome, nome);

            if (string.IsNullOrEmpty(id))
                throw new BusinessManagedException(ErrorCodes.BadRequest.ToString());

            if (!CheckPermissionBase(Permissions.CreatePazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var existingPaziente = Database.Pazienti.SingleOrDefault(x => x.IdPaziente == id);

            if (existingPaziente != null)
                throw new BusinessManagedException(ErrorCodes.DuplicatePaziente.ToString());

            var newPaziente = Database.Pazienti.Add(new Paziente()
            {
                IdPaziente = id,
                AnnoNascita = annoNascita,
                City = city,
                CodiceFiscale = codiceFiscale,
                CognomePaziente = cognome,
                NomePaziente = nome,
                NumeroCellulare = numeroCellulare,
                Sesso = sesso,
                Education = education,
                Indirizzo = indirizzo,
                IndirizzoMail = indirizzoMail
            });

            Database.SaveChanges();

            return newPaziente.Entity;
        }

        public Paziente UpdatePaziente(string id, string city, string codiceFiscale, string cognome, string nome, string numeroCellulare, string sesso, int? education, string indirizzo, string indirizzoMail, int? annoNascita)
        {
            _logger.LogInformation("Updating paziente id {0} - {1} {2}", id, cognome, nome);

            if (string.IsNullOrEmpty(id))
                throw new BusinessManagedException(ErrorCodes.BadRequest.ToString(), "id is empty");

            var toUpdate = Database.Pazienti.SingleOrDefault(x => x.IdPaziente == id);

            if (toUpdate == null)
                throw new BusinessManagedException(ErrorCodes.NotFound.ToString(), "didnt find paziente to update");

            if (!CheckPermissionBase(Permissions.UpdatePazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString(), "role not enabled for this update");

            toUpdate.City = city;
            toUpdate.CodiceFiscale = codiceFiscale;
            toUpdate.CognomePaziente = cognome;
            toUpdate.NomePaziente = nome;
            toUpdate.NumeroCellulare = numeroCellulare;
            toUpdate.Sesso = sesso;
            toUpdate.Education = education;
            toUpdate.Indirizzo = indirizzo;
            toUpdate.IndirizzoMail = indirizzoMail;
            toUpdate.AnnoNascita = annoNascita;

            Database.SaveChanges();

            return toUpdate;
        }

        public void DeletePaziente(string id)
        {
            var toDelete = Database.Pazienti.SingleOrDefault(x => x.IdPaziente == id);

            if (toDelete == null)
                throw new BusinessManagedException(ErrorCodes.NotFound.ToString(), "didnt find paziente to update");

            _logger.LogInformation("Deleting paziente {0}", toDelete.IdPaziente);

            if (!CheckPermissionBase(Permissions.DeletePazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString(), "role not enabled for this deletion");

            toDelete.Deleted = true;

            Database.SaveChanges();
        }

        public IEnumerable<EsamePazienteProxy> GetEsamiPaziente(string idPaziente)
        {
            _logger.LogInformation("Requesting esami paziente {0}", idPaziente);

            if (!CheckPermissionBase(Permissions.ReadEsamiPazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var queryResult = Database
                .GetEsamiPaziente(idPaziente)
                .ToList();

            var immagini = Database.GetImmagini(idPaziente).Include(x => x.RegioniDiInteresse).ToList();

            return queryResult
                .GroupBy(key => new { key.Data, key.DescrizionePatologia, key.DescrizionePaziente, key.DescrizioneTipoEsame, key.IdEsame, key.IdPatologia, key.IdPaziente, key.IdTipoEsame, key.RichiedeImmagini })
                .Select(esame => new EsamePazienteProxy()
                {
                    Data = esame.Key.Data,
                    RichiedeImmagini = esame.Key.RichiedeImmagini,
                    DescrizionePatologia = esame.Key.DescrizionePatologia,
                    DescrizionePaziente = esame.Key.DescrizionePaziente,
                    DescrizioneTipoEsame = esame.Key.DescrizioneTipoEsame,
                    IdEsame = esame.Key.IdEsame,
                    IdPatologia = esame.Key.IdPatologia,
                    IdPaziente = esame.Key.IdPaziente,
                    IdTipoEsame = esame.Key.IdTipoEsame,
                    Features = esame
                    .Where(x => x.IdFeature != null)
                    .Select(feature_esame => new FeatureEsameProxy()
                    {
                        IdFeature = feature_esame.IdFeature,
                        Descrizione = feature_esame.DescrizioneFeature,
                        TipoValore = feature_esame.TipoValoreFeature?.ToString(),
                        Valore = feature_esame.ValoreFeature
                    }),
                    Immagini = immagini
                           .Where(immagine => immagine.IdEsame == esame.Key.IdEsame)
                           .Select(immagine => new ImmagineProxy()
                           {
                               DataCaricamento = immagine.CreationDate,
                               Dimensione = immagine.Dimensione,
                               ID = immagine.Id,
                               IdEsame = immagine.IdEsame,
                               Nome = immagine.NomeFile,
                               RegioniDiInteresse = immagine.RegioniDiInteresse?.Select(x => new RegionOfInterestProxy()
                               {
                                   ID = x.Id,
                                   NomeFile = x.NomeFile
                               }),
                               Features = esame
                                            .Where(i => i.IdImmagine.HasValue && i.IdImmagine.Value == immagine.Id)
                                            .Select(feature_immagine => new FeatureEsameProxy()
                                            {
                                                IdFeature = feature_immagine.IdFeature,
                                                Descrizione = feature_immagine.DescrizioneFeature,
                                                TipoValore = feature_immagine.TipoValoreFeature.ToString(),
                                                Valore = feature_immagine.ValoreFeature
                                            }),
                           })
                }).ToList();

            /*
                .Select(esame => new EsamePazienteProxy()
                {
                    Data = esame.Data,
                    DescrizionePaziente = esame.Paziente.CognomePaziente + " " + esame.Paziente.NomePaziente,
                    DescrizionePatologia = esame.Patologia.Descrizione,                    
                    IdEsame = esame.IdEsame,
                    IdPaziente = esame.IdPaziente,
                    IdPatologia = esame.IdPatologia,
                    IdTipoEsame = esame.IdTipoEsame,
                    DescrizioneTipoEsame = esame.TipoEsame.Descrizione,
                    Features = esame.FeaturesEsame
                                    .Select(feature_esame => new FeatureEsameProxy()
                                        {
                                            IdFeature = feature_esame.Feature.IdFeature,
                                            Descrizione = feature_esame.Feature.Descrizione,
                                            TipoValore = feature_esame.Feature.TipoValore.ToString(),
                                            Valore = feature_esame.Valore
                                        }),
                    Immagini = esame.Immagini
                                    .Select(immagine => new ImmagineProxy()
                                        {
                                            DataCaricamento = immagine.CreationDate,
                                            Dimensione = immagine.Dimensione,
                                            ID = immagine.Id,
                                            IdEsame = immagine.IdEsame,
                                            Nome = immagine.NomeFile,

                                            Features = esame.FeaturesEsame
                                                            .Where(feature_esame => feature_esame.IdImmagine.HasValue && feature_esame.IdImmagine.Value == immagine.Id)
                                                            .Select(feature_immagine => new FeatureEsameProxy()
                                                                {
                                                                    IdFeature = feature_immagine.Feature.IdFeature,
                                                                    Descrizione = feature_immagine.Feature.Descrizione,
                                                                    TipoValore = feature_immagine.Feature.TipoValore.ToString(),
                                                                    Valore = feature_immagine.Valore
                                                                }),

                                            RegioniDiInteresse = immagine.RegioniDiInteresse
                                                                            .Select(roi => new RegionOfInterestProxy()
                                                                            {
                                                                                Dimensione = 0,
                                                                                ID = roi.Id,
                                                                                IdImmagine = roi.IdImmagine,
                                                                                NomeFile = roi.NomeFile,
                                                                                NomeFileImmagine = roi.Immagine.NomeFile,
                                                                                Features = esame.FeaturesEsame
                                                                                                .Where(feature_esame => feature_esame.IdImmagine.HasValue && feature_esame.IdImmagine.Value == immagine.Id)
                                                                                                .Select(feature_roi => new FeatureEsameProxy()
                                                                                {
                                                                                    IdFeature = feature_roi.Feature.IdFeature,
                                                                                    Descrizione = feature_roi.Feature.Descrizione,
                                                                                    TipoValore = feature_roi.Feature.TipoValore.ToString(),
                                                                                    Valore = feature_roi.Valore
                                                                                }),
                                                                            })
                                        })                    
                })
                .ToList();
            */
        }

        public IEnumerable<PredizioneProxy> GetPredizioniPaziente(string idPaziente)
        {
            _logger.LogInformation("Requesting predizioni paziente {0}", idPaziente);

            if (!CheckPermissionBase(Permissions.ReadEsamiPazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            return Database
                .GetPredizioni(idPaziente)
                .Select(predizione => new PredizioneProxy()
                {
                    ID = predizione.Id,
                    IdAlgoritmo = predizione.IdAlgoritmo,
                    IdPatologia = predizione.IdPatologia,
                    IdPaziente = predizione.IdPaziente,
                    DataRichiesta = predizione.CreationDate,
                    DescrizioneAlgoritmo = predizione.Algoritmo.Descrizione,
                    DescrizionePatologia = predizione.Patologia.Descrizione,
                    DescrizionePaziente = predizione.Paziente.CognomePaziente + " " + predizione.Paziente.NomePaziente,
                    EsitoPredizione = predizione.Esito
                });
        }

        public IEnumerable<DiagnosiProxy> GetDiagnosiPaziente(string idPaziente)
        {
            _logger.LogInformation("Requesting diagnosi paziente {0}", idPaziente);

            if (!CheckPermissionBase(Permissions.ReadEsamiPazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            return Database
                .GetDiagnosi(idPaziente)
                .Select(diagnosi => new DiagnosiProxy()
                {
                    IdPatologia = diagnosi.IdPatologia,
                    IdPaziente = diagnosi.IdPaziente,
                    Data = diagnosi.Date,
                    DescrizionePatologia = diagnosi.Patologia.Descrizione,
                    DescrizionePaziente = diagnosi.Paziente.CognomePaziente + " " + diagnosi.Paziente.NomePaziente,
                    Esito = diagnosi.Esito
                });
        }

        public void SaveDiagnosi(string idPaziente, string idPatologia, DateTime date, string esito)
        {
            _logger.LogInformation("Save diagnosi paziente {0} {1}", idPaziente, idPatologia);

            if (!CheckPermissionBase(Permissions.ReadEsamiPazienti))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            Database.Diagnosi.Add(new Diagnosi()
            {
                IdPaziente = idPaziente,
                IdPatologia = idPatologia,
                Date = date,
                Esito = esito
            });

            Database.SaveChanges();
        }

        public int CreateImmagine(string idPaziente, int idEsame, string fileName, long fileLength)
        {
            _logger.LogInformation("Requesting esami paziente {0}", idPaziente);

            if (!CheckPermissionBase(Permissions.UploadImmagineEsame))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var immagine = Database.Immagini.Add(new Immagine()
            {
                DataCaricamento = DateTime.Now,
                Dimensione = fileLength,
                IdEsame = idEsame,
                NomeFile = fileName,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            }).Entity;

            Database.SaveChanges();

            return immagine.Id;
        }

        public int CreateRoi(int idImmagine, string fileName, long fileLength)
        {
            _logger.LogInformation("Requesting esami paziente {0}", idImmagine);

            if (!CheckPermissionBase(Permissions.UploadImmagineEsame))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var roi = Database.RegioniDiInteresse.Add(new RegioneDiInteresse()
            {
                DataCaricamento = DateTime.Now,
                IdImmagine = idImmagine,                
                NomeFile = fileName,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            }).Entity;

            Database.SaveChanges();

            return roi.Id;
        }

        public void SaveFeatureEsame(int idEsame, string idFeature, string valore, int? idImmagine = null, int? idRoi = null)
        {
            _logger.LogInformation("Requesting esami paziente {0}", idEsame.ToString());

            if (!CheckPermissionBase(Permissions.UploadImmagineEsame))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            if (idRoi.HasValue)
            {
                idImmagine = Database.RegioniDiInteresse.SingleOrDefault(x => x.Id == idRoi.Value)?.IdImmagine;

                if(!idImmagine.HasValue)
                    throw new BusinessManagedException(ErrorCodes.NotFound.ToString());
            }

            var esame = Database.Esami.SingleOrDefault(x => x.IdEsame == idEsame);

            if (esame == null)
                throw new BusinessManagedException(ErrorCodes.NotFound.ToString());

            var feature = Database.Features.SingleOrDefault(x => x.IdPatologia == esame.IdPatologia && x.IdTipoEsame == esame.IdTipoEsame && x.IdFeature == idFeature);

            if (feature == null)
            {
                feature = Database.Features.Add(new Feature()
                {
                    IdFeature = idFeature,
                    Descrizione = "",
                    IdPatologia = esame.IdPatologia,
                    IdTipoEsame = esame.IdTipoEsame,
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    TipoValore = 0,
                    DataInizioValidita = DateTime.Now,
                    DataFineValidita = DateTime.Now,
                }).Entity;

                Database.SaveChanges();
            }

            var featureEsame = Database.FeaturesEsame.SingleOrDefault(x => 
                                                                            x.IdFeature == feature.Id && 
                                                                            x.IdEsame == idEsame && 
                                                                            x.IdImmagine == idImmagine && 
                                                                            x.IdRegioneDiInteresse == idRoi
                                                                      );

            if (featureEsame == null)
                featureEsame = Database.FeaturesEsame.Add(new FeatureEsame()
                {
                    CreationDate = DateTime.Now,
                    IdEsame = idEsame,
                    IdFeature = feature.Id,
                    IdImmagine = idImmagine,
                    IdRegioneDiInteresse = idRoi,
                    LastUpdateDate = DateTime.Now                    
                }).Entity;

            featureEsame.Valore = valore;

            Database.SaveChanges();
        }

        public int SaveEsame(string idPaziente, string idPatologia, string idTipoEsame, DateTime date)
        {
            _logger.LogInformation("Saving esame paziente");

            if (!CheckPermissionBase(Permissions.UploadImmagineEsame))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var existingEsame = Database.Esami.SingleOrDefault(x => x.IdPaziente == idPaziente && x.IdPatologia == idPatologia && x.IdTipoEsame == idTipoEsame && x.Data.Date == date.Date);

            if (existingEsame != null)
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            existingEsame = Database.Esami.Add(new Esame()
            {
                IdPaziente = idPaziente,
                IdPatologia = idPatologia,
                IdTipoEsame = idTipoEsame,
                Data = date
            }).Entity;

            Database.SaveChanges();

            return existingEsame.IdEsame;
        }
    }
}
