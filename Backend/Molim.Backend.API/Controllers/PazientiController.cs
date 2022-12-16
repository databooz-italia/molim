using System.Collections.Generic;
using System.Linq;
using Molim.Backend.API.Auth;
using Molim.Backend.API.BusinessLayer.Services.Authentication;
using Molim.Backend.API.DTO.Accounts.Requests;
using Molim.Backend.API.DTO.Accounts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Molim.Backend.API.Mappers;
using Molim.Backend.API.BusinessLayer.Services;
using Molim.Backend.API.DTO.Pazienti.Responses;
using Molim.Backend.API.DTO.Pazienti.Requests;
using Molim.Backend.API.DTO.Pazienti.Esami.Responses;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Molim.Backend.API.Exceptions;
using Molim.Backend.API.DTO.Pazienti.Esami;
using Molim.Backend.API.DTO.Pazienti.Predizioni.Responses;
using Molim.Backend.API.DTO.Pazienti.Predizioni;
using Molim.Backend.API.DTO.Pazienti.Diagnosi.Responses;
using Molim.Backend.API.DTO.Pazienti.Diagnosi;
using Molim.Backend.API.DTO.Pazienti.Diagnosi.Requests;
using Molim.Backend.API.DTO.Pazienti.Predizioni.Requests;
using System.Threading.Tasks;
using Molim.Backend.API.BusinessLayer.Data.Entities;

namespace Molim.Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PazientiController : ControllerBase
    {
        private readonly ILogger<PazientiController> _logger;
        private readonly BaseService _uow;
        private readonly IWebHostEnvironment _env;

        public PazientiController(ILogger<PazientiController> logger, BaseService uow, IWebHostEnvironment env)
        {
            _logger = logger;
            _uow = uow;
            _env = env;
        }

        #region PAZIENTI

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public GetPazientiResponse GetPazienti()
        {
            IEnumerable<DTO.Pazienti.PazienteDTO> pazienti;

            using (_uow)
            {
                var service = new PazientiService(_uow);

                pazienti = service
                    .GetPazienti()
                    .Select(x => PazientiMapper.Map(x));
            }

            return new GetPazientiResponse()
            {
                Pazienti = pazienti
            };
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreatePaziente([FromBody] CreatePazienteRequest request)
        {
            using (_uow)
            {
                var service = new PazientiService(_uow);
                service.CreatePaziente(
                    id: request.IdPaziente,
                    city: request.City,
                    codiceFiscale: request.CodiceFiscale,
                    cognome: request.CognomePaziente,
                    nome: request.NomePaziente,
                    numeroCellulare: request.NumeroCellulare,
                    sesso: request.Sesso,
                    education: request.Education,
                    indirizzo: request.Indirizzo,
                    indirizzoMail: request.IndirizzoMail,
                    annoNascita: request.AnnoNascita
                    );

                _uow.Complete();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdatePaziente([FromBody] UpdatePazienteRequest request, string id)
        {
            using (_uow)
            {
                var service = new PazientiService(_uow);
                service.UpdatePaziente(
                    id: id,
                    city: request.City,
                    codiceFiscale: request.CodiceFiscale,
                    cognome: request.CognomePaziente,
                    nome: request.NomePaziente,
                    numeroCellulare: request.NumeroCellulare,
                    sesso: request.Sesso,
                    education: request.Education,
                    indirizzo: request.Indirizzo,
                    indirizzoMail: request.IndirizzoMail,
                    annoNascita: request.AnnoNascita
                    );

                _uow.Complete();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DeletePaziente(string id)
        {
            using (_uow)
            {
                var service = new PazientiService(_uow);
                service.DeletePaziente(id);

                _uow.Complete();
            }

            return Ok();
        }

        #endregion

        #region ESAMI

        [HttpGet("{idPaziente}/esami")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public GetEsamiPazienteResponse GetEsamiPaziente(string idPaziente)
        {
            IEnumerable<DTO.Pazienti.Esami.EsamePazienteDTO> esami;

            using (_uow)
            {
                var service = new PazientiService(_uow);

                esami = service
                    .GetEsamiPaziente(idPaziente)
                    .Select(x => PazientiMapper.Map(x));
            }

            return new GetEsamiPazienteResponse()
            {
                EsamiPaziente = esami?.GroupBy(x => x.IdPatologia)?.ToDictionary(k => k.Key, v => v.AsEnumerable())
            };
        }

        [HttpPost("{idPaziente}/esami")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public int SaveEsame([FromBody] EsamePazienteDTO esame)
        {
            int idEsame = -1;

            using (_uow)
            {
                var service = new PazientiService(_uow);
                idEsame = service.SaveEsame(
                        esame.IdPaziente,
                        esame.IdPatologia,
                        esame.IdTipoEsame,
                        esame.Data
                    );

                _uow.Complete();
            }

            return idEsame;
        }

        #region IMMAGINI ESAMI

        [HttpGet("{idPaziente}/{idEsame}/immagini/{idImmagine}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public PhysicalFileResult DownloadFileImmagine(string idPaziente, int idEsame, int idImmagine)
        {
            var immaginePath = GetPathImmagine(idImmagine);

            if (!System.IO.File.Exists(immaginePath))
                throw new ManagedException(ManagedException.ExceptionCodes.Generic);

            return PhysicalFile(immaginePath, "application/octet-stream");
        }

        [HttpPost("{idPaziente}/{idEsame}/immagini")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public int UploadFileEsame(IFormFile file)
        {
            var idPaziente = (string)Request.RouteValues["idPaziente"];
            var idEsame = int.Parse((string)Request.RouteValues["idEsame"]);

            int idImmagine = -1;

            using (_uow)
            {
                var service = new PazientiService(_uow);
                idImmagine = service.CreateImmagine(
                        idPaziente, idEsame, file.FileName, file.Length
                    );

                _uow.Complete();
            }

            if (idImmagine < 0)
                throw new ManagedException(ManagedException.ExceptionCodes.Generic);

            if (file == null || file.Length <= 0)
                throw new ManagedException(ManagedException.ExceptionCodes.Generic);

            var filePath = GetPathImmagine(idImmagine);

            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                file.CopyTo(stream);

            return idImmagine;
        }

        [HttpPost("{idImmagine}/roi")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public int UploadROIImmagine(IFormFile file)
        {
            var idImmagine = int.Parse((string)Request.RouteValues["idImmagine"]);

            int idRoi = -1;

            using (_uow)
            {
                var service = new PazientiService(_uow);
                idRoi = service.CreateRoi(
                        idImmagine, file.FileName, file.Length
                    );

                _uow.Complete();
            }

            if (idRoi < 0)
                throw new ManagedException(ManagedException.ExceptionCodes.Generic);

            if (file == null || file.Length <= 0)
                throw new ManagedException(ManagedException.ExceptionCodes.Generic);

            var filePath = GetPathImmagine(idImmagine);

            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                file.CopyTo(stream);

            return idRoi;
        }

        #region FEATURE ESAMI

        [HttpPost("{idPaziente}/{idEsame}/features")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult SaveFeatureEsame(string idPaziente, int idEsame, [FromBody] List<FeatureEsameDTO> featureEsame)
        {
            using (_uow)
            {
                var service = new PazientiService(_uow);

                if (featureEsame != null)
                    foreach (var fe in featureEsame)
                        service.SaveFeatureEsame(
                                idEsame,
                                fe.IdFeature,
                                fe.Valore.ToString(),
                                fe.IdImmagine,
                                fe.IdROI
                            );

                _uow.Complete();
            }

            return Ok();
        }

        #endregion

        #endregion

        #endregion

        #region PREDIZIONI

        [HttpGet("{idPaziente}/predizioni")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public GetPredizioniPazienteResponse GetPredizioniPaziente(string idPaziente)
        {
            IEnumerable<PredizioneDTO> diagnosi;

            using (_uow)
            {
                var service = new PazientiService(_uow);

                diagnosi = service
                    .GetPredizioniPaziente(idPaziente)
                    .Select(x => PazientiMapper.Map(x));
            }

            return new GetPredizioniPazienteResponse()
            {
                PredizioniPaziente = diagnosi?.GroupBy(x => x.IdPatologia)?.ToDictionary(k => k.Key, v => v.AsEnumerable())
            };
        }

        [HttpPost("{idPaziente}/predizioni")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<GetPredizioniPazienteResponse> CreatePredizionePaziente(CreatePredizionePaziente req)
        {
            RichiestaEsecuzione richiesta = null;

            using (_uow)
            {
                var service = new Molim.Backend.API.MSClient.ManagerRichiesteEsecuzioneMS(_uow);

                richiesta = await service.CreateRichiestaEsecuzione(req.IdAlgoritmo, req.IdPaziente, req.IdImmagine, req.IdRegioneDiInteresse, req.IdPatologia);
                _uow.Complete();
            }

            if (richiesta.DataCompletamento.HasValue)
                return GetPredizioniPaziente(req.IdPaziente);

            throw new System.Exception();
        }

        #endregion

        #region DIAGNOSI

        [HttpGet("{idPaziente}/diagnosi")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public GetDiagnosiPazienteResponse GetDiagnosiPaziente(string idPaziente)
        {
            IEnumerable<DiagnosiDTO> diagnosi;

            using (_uow)
            {
                var service = new PazientiService(_uow);

                diagnosi = service
                    .GetDiagnosiPaziente(idPaziente)
                    .Select(x => PazientiMapper.Map(x));
            }

            return new GetDiagnosiPazienteResponse()
            {
                DiagnosiPaziente = diagnosi?.GroupBy(x => x.IdPatologia)?.ToDictionary(k => k.Key, v => v.AsEnumerable())
            };
        }

        [HttpPost("{idPaziente}/diagnosi")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreaDiagnosiPaziente([FromBody] CreaDiagnosiRequest diagnosi)
        {
            using (_uow)
            {
                var service = new PazientiService(_uow);

                service.SaveDiagnosi(
                        diagnosi.IdPaziente,
                        diagnosi.IdPatologia,
                        diagnosi.Date,
                        diagnosi.Esito
                    );

                _uow.Complete();
            }

            return Ok();
        }

        #endregion

        private string GetPathImmagine(int idImmagine, bool isRoi = false)
        {
            var immaginiPath = System.IO.Path.Combine(_env.ContentRootPath, isRoi ? "roi" : "immagini");

            if (!System.IO.Directory.Exists(immaginiPath))
                System.IO.Directory.CreateDirectory(immaginiPath);

            return System.IO.Path.Combine(immaginiPath, idImmagine.ToString());
        }
    }
}