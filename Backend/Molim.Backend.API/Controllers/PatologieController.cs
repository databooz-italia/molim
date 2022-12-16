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
using Molim.Backend.API.DTO.Patologie.Responses;
using Molim.Backend.API.BusinessLayer.Services.Patologie;

namespace Molim.Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatologieController : ControllerBase
    {
        private readonly ILogger<PatologieController> _logger;
        private readonly BaseService _uow;

        public PatologieController(ILogger<PatologieController> logger, BaseService uow)
        {
            _logger = logger;
            _uow = uow;
        }

        //ALGORITMI

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public GetPatologieResponse GetPatologie()
        {
            IEnumerable<DTO.Patologie.PatologiaDTO> patologie;

            using (_uow)
            {
                var service = new PatologieService(_uow);

                patologie = service
                    .GetPatologie()
                    .Select(x => PatologieMapper.Map(x));
            }

            return new GetPatologieResponse()
            {
                Patologie = patologie
            };
        }        
    }
}