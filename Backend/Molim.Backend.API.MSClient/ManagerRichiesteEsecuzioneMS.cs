using Microsoft.Extensions.Logging;
using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Exceptions;
using Molim.Backend.API.BusinessLayer.Interfaces;
using Molim.Backend.API.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molim.Backend.API.MSClient
{
    public class ManagerRichiesteEsecuzioneMS : IManagerRichiesteEsecuzione
    {
        //private const string MS_INIT_PHASE = "INIT";
        private const string MS_LOAD_INPUTS_PHASE = "LOAD_INPUTS";
        private const string MS_LOAD_RESOURCES_PHASE = "LOAD_RESOURCES";
        private const string MS_RUN_PHASE = "RUN";
        private const string MS_STATUS_LOADED_PHASE = "STATUS_LOADED";
        private const string MS_STATUS_DONE_PHASE = "STATUS_DONE";
        private const string MS_OUTPUT_PHASE = "OUTPUT";
        //private const string MS_UUID = "UUID";

        public ManagerRichiesteEsecuzioneMS(BaseService bs) : base(bs)
        {

        }

        public ManagerRichiesteEsecuzioneMS(MolimDb db, Configuration conf, IAuthenticationProvider auth, ILogger logger) : base(db, conf, auth, logger)
        {

        }

        public class ParametriRichiesta
        {
            public string UUID_RICHIESTA { get; set; }
        }

        protected override async Task<string> InitializeParametriRichiesta(RichiestaEsecuzione richiesta)
        {
            var parameters = new ParametriRichiesta();

            TaskHandle ret;

            //parameters.UUID_RICHIESTA = Guid.NewGuid().ToString();
            
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                var client = new HttpClient(richiesta.Algoritmo.EndpointRest, httpClient);
                ret = await client.InitAsync();
                parameters.UUID_RICHIESTA = ret.Uuid.ToString();
            }           

            return Serialize<ParametriRichiesta>(parameters);
        }

        protected override void InitializeFasiRichiestaEsecuzioni(RichiestaEsecuzione richiesta)
        {
            richiesta.Fasi = new List<RichiestaEsecuzioneFase>();

            /*richiesta.Fasi.Add(new RichiestaEsecuzioneFase()
            {
                Ordine = 0,
                Data = DateTime.Now,
                IdFase = MS_INIT_PHASE,
                Status = IManagerRichiesteEsecuzione.StatiRichieste.ATTESA.ToString()
            });*/

            richiesta.Fasi.Add(new RichiestaEsecuzioneFase()
            {
                IdRichiestaEsecuzione = richiesta.ID,
                Ordine = 1,
                Data = DateTime.Now,
                IdFase = MS_LOAD_INPUTS_PHASE,
                Status = IManagerRichiesteEsecuzione.StatiRichieste.ATTESA.ToString()
            });

            richiesta.Fasi.Add(new RichiestaEsecuzioneFase()
            {
                IdRichiestaEsecuzione = richiesta.ID,
                Ordine = 2,
                Data = DateTime.Now,
                IdFase = MS_STATUS_LOADED_PHASE,
                Status = IManagerRichiesteEsecuzione.StatiRichieste.ATTESA.ToString()
            });

            /*
            richiesta.Fasi.Add(new RichiestaEsecuzioneFase()
            {
                Ordine = 1,
                Data = DateTime.Now,
                IdFase = MS_LOAD_RESOURCES_PHASE,
                Status = IManagerRichiesteEsecuzione.StatiRichieste.ATTESA.ToString()
            });
            */

            richiesta.Fasi.Add(new RichiestaEsecuzioneFase()
            {
                IdRichiestaEsecuzione = richiesta.ID,
                Ordine = 3,
                Data = DateTime.Now,
                IdFase = MS_RUN_PHASE,
                Status = IManagerRichiesteEsecuzione.StatiRichieste.ATTESA.ToString()
            });            

            /*richiesta.Fasi.Add(new RichiestaEsecuzioneFase()
            {
                IdRichiestaEsecuzione = richiesta.ID,
                Ordine = 4,
                Data = DateTime.Now,
                IdFase = MS_OUTPUT_PHASE,
                Status = IManagerRichiesteEsecuzione.StatiRichieste.ATTESA.ToString()
            });*/
        }

        protected override async System.Threading.Tasks.Task RunFaseRichiestaEsecuzione(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase)
        {
            switch (fase.IdFase)
            {
                /*case MS_INIT_PHASE:

                    FaseInit(richiesta, fase);

                    break;
                */
                case MS_LOAD_INPUTS_PHASE:

                    await FaseLoadInput(richiesta, fase);

                    break;

                case MS_LOAD_RESOURCES_PHASE:

                    await FaseLoadResources(richiesta, fase);

                    break;

                case MS_STATUS_LOADED_PHASE:

                    await FaseStatus(richiesta, fase, TaskStatus.LOADED);

                    break;

                case MS_RUN_PHASE:

                    await FaseRun(richiesta, fase);

                    break;

                case MS_STATUS_DONE_PHASE:

                    await FaseStatus(richiesta, fase, TaskStatus.DONE);

                    break;

                case MS_OUTPUT_PHASE:

                    await FaseOutput(richiesta, fase);

                    break;

                default:
                    throw new BusinessManagedException("FASE_NON_CENSITA");
            }
        }

        /*private async void FaseInit(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase)
        {
            
        }*/

        private async System.Threading.Tasks.Task FaseLoadInput(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase)
        {
            var parameters = Deserialize<ParametriRichiesta>(richiesta.Parametri);

            if (string.IsNullOrEmpty(parameters?.UUID_RICHIESTA))
                throw new BusinessManagedException("UUID_NON_PRESENTE");

            Dictionary<string, object> algorithmValues = new Dictionary<string, object>();

            if (richiesta.Algoritmo.Features != null)
                foreach (var algorithmFeature in richiesta.Algoritmo.Features)
                {
                    //Prendo l'ultimo valore registrato per la feature richiesta
                    var patientFeature = richiesta.Paziente
                                                  ?.Esami
                                                  ?.Where(x => x.IdPatologia == richiesta.IdPatologia)
                                                  ?.SelectMany(x => x.FeaturesEsame)
                                                  ?.Where(x => 
                                                                x.IdFeature == algorithmFeature.IdFeature && 
                                                                //O sono delle feature inserite manualmente o sono quelle dell immagine per cui è richiesta la predizione
                                                                (!x.IdImmagine.HasValue || x.IdImmagine == richiesta.IdImmagine)
                                                                 && 
                                                                 //O sono delle feature inserite manualmente o sono quelle della ROI per cui è richiesta la predizione
                                                                (!x.IdImmagine.HasValue || x.IdRegioneDiInteresse == richiesta.IdRegioneDiInteresse)
                                                         )
                                                  ?.OrderByDescending(x => x.LastUpdateDate)
                                                  ?.FirstOrDefault();

                    //Se non la trovo
                    if (patientFeature == null)
                    {
                        //Se è obbligatoria do errore
                        if (algorithmFeature.Obbligatorio)
                            throw new Exception($"Feature {algorithmFeature.Feature.IdFeature} obbligatoria non trovata per il paziente!");
                    }
                    else
                        //Altrimenti la aggiungo nella richiesta
                        algorithmValues.Add(algorithmFeature.Feature.IdFeature, patientFeature.Valore);
                }            

            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                _logger.LogInformation($"FaseLoadInput - {parameters.UUID_RICHIESTA}, Request:\n\r{Newtonsoft.Json.JsonConvert.SerializeObject(algorithmValues)}");

                var client = new HttpClient(richiesta.Algoritmo.EndpointRest, httpClient);
                var ret = await client.LoadAsync(new Guid(parameters.UUID_RICHIESTA), new SampleInput()
                {
                    AdditionalProperties = algorithmValues
                });

                if (ret == null || ret.Status != TaskStatus.INIT)
                    throw new Exception("Risposta al load non coerente!");

                _logger.LogInformation($"FaseLoadInput - {parameters.UUID_RICHIESTA} RETURN:\n\r{Newtonsoft.Json.JsonConvert.SerializeObject(ret)}");
            }
        }

        private async System.Threading.Tasks.Task FaseLoadResources(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase)
        {
            var parameters = Deserialize<ParametriRichiesta>(richiesta.Parametri);

            if (string.IsNullOrEmpty(parameters.UUID_RICHIESTA))
                throw new BusinessManagedException("UUID_NON_PRESENTE");

            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                var client = new HttpClient(richiesta.Algoritmo.EndpointRest, httpClient);

                string fileName = richiesta.RegioneDiInteresse?.NomeFile ?? richiesta.Immagine.NomeFile;
                string filePath = fileName;//richiesta.RegioneDiInteresse? ?? parameters.Path_Immagine;

                if (!System.IO.File.Exists(filePath))
                    throw new NotImplementedException("Download del file non disponibile");

                using (Stream s = new FileStream(filePath, FileMode.Open))
                {
                    var fileParameter = new FileParameter(s, fileName, "application/octet-stream");
                    var fileParametersList = new List<FileParameter>();
                    fileParametersList.Add(fileParameter);

                    await client.UploadAsync(new Guid(parameters.UUID_RICHIESTA), fileParametersList);
                }
            }
        }

        private async System.Threading.Tasks.Task FaseRun(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase)
        {
            var parameters = Deserialize<ParametriRichiesta>(richiesta.Parametri);

            if (string.IsNullOrEmpty(parameters.UUID_RICHIESTA))
                throw new BusinessManagedException("UUID_NON_PRESENTE");

            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                _logger.LogInformation($"FaseRun - REQUEST {parameters.UUID_RICHIESTA}");

                var client = new HttpClient(richiesta.Algoritmo.EndpointRest, httpClient);
                var response = await client.RunAsync(new Guid(parameters.UUID_RICHIESTA));

                if (response.Output != null)
                    richiesta.Risultato = response.Output;

                _logger.LogInformation($"FaseRun - {parameters.UUID_RICHIESTA} RETURN:\n\r{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");
            }
        }

        private async System.Threading.Tasks.Task FaseStatus(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase, TaskStatus statusToCheck)
        {
            var parameters = Deserialize<ParametriRichiesta>(richiesta.Parametri);

            if (string.IsNullOrEmpty(parameters.UUID_RICHIESTA))
                throw new BusinessManagedException("UUID_NON_PRESENTE");

            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                _logger.LogInformation($"FaseStatus - REQUEST {parameters.UUID_RICHIESTA}");

                var client = new HttpClient(richiesta.Algoritmo.EndpointRest, httpClient);

                var res = await client.CheckAsync(new Guid(parameters.UUID_RICHIESTA));

                if (res.Status != statusToCheck)
                    throw new Exception($"Status of request {res.Status.ToString()} instead of {statusToCheck.ToString()}");

                _logger.LogInformation($"FaseStatus - RESPONSE:\n\r{Newtonsoft.Json.JsonConvert.SerializeObject(res)}");
                //TODO INVIO MAIL
            }
        }

        private async System.Threading.Tasks.Task FaseOutput(RichiestaEsecuzione richiesta, RichiestaEsecuzioneFase fase)
        {
            var parameters = Deserialize<ParametriRichiesta>(richiesta.Parametri);

            if (string.IsNullOrEmpty(parameters.UUID_RICHIESTA))
                throw new BusinessManagedException("UUID_NON_PRESENTE");

            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                var client = new HttpClient(richiesta.Algoritmo.EndpointRest, httpClient);

                var res = await client.CheckAsync(new Guid(parameters.UUID_RICHIESTA));

                if (res.Status != TaskStatus.DONE)
                    throw new Exception($"Status of request {res.Status.ToString()} instead of {TaskStatus.DONE.ToString()}");

                richiesta.Risultato = res.Output;
            }
        }        
    }
}
