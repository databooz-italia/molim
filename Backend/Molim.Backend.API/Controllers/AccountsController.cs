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

namespace Molim.Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly BaseService _uow;
        private readonly TokensProvider _tokensProvider;

        public AccountsController(ILogger<AccountsController> logger, BaseService uow, TokensProvider tokenProvider)
        {
            _logger = logger;
            _uow = uow;
            _tokensProvider = tokenProvider; 
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]        
        public GetAccountsResponse GetAccounts(string roleType)
        {
            IEnumerable<DTO.Accounts.AccountDTO> accounts;

            using (_uow)
            {
                var service = new AccountsService(_uow);

                accounts = service
                    .GetAccounts(roleType)
                    .Select(x => AccountsMapper.Map(x));
            }

            return new GetAccountsResponse()
            {
                Accounts = accounts
            };
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateAccount([FromBody]CreateAccountRequest request)
        {            
            using(_uow)
            {
                var service = new AccountsService(_uow);
                service.CreateAccount(request.Username, request.FirstName, request.LastName, request.Password, request.Bookings, request.BookingsToDate, request.RoleType, request.AccountType_ID);

                _uow.Complete();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]        
        public IActionResult UpdateAccount([FromBody] UpdateAccountRequest request, int id)
        {
            using (_uow)
            {
                var service = new AccountsService(_uow);
                service.UpdateAccount(id, request.Username, request.FirstName, request.LastName, request.Password, request.Bookings, request.BookingsToDate, request.AccountType_ID, request.Version);

                _uow.Complete();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DeleteAccount(int id)
        {
            using (_uow)
            {
                var service = new AccountsService(_uow);
                service.DeleteAccount(id);

                _uow.Complete();
            }

            return Ok();
        }
    }
}