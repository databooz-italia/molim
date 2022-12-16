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
using Molim.Backend.API.DTO.Algoritmi.Responses;

namespace Molim.Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlgoritmiController : ControllerBase
    {
        private readonly ILogger<AlgoritmiController> _logger;
        private readonly BaseService _uow;

        public AlgoritmiController(ILogger<AlgoritmiController> logger, BaseService uow)
        {
            _logger = logger;
            _uow = uow;
        }

        //ALGORITMI

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public GetAlgoritmiResponse GetAlgoritmi()
        {
            IEnumerable<DTO.Algoritmi.AlgoritmoDTO> algoritmi;

            using (_uow)
            {
                var service = new AlgoritmiService(_uow);

                algoritmi = service
                    .GetAlgoritmi()
                    .Select(x => AlgoritmiMapper.Map(x));
            }

            return new GetAlgoritmiResponse()
            {
                Algoritmi = algoritmi
            };
        }        
    }
}