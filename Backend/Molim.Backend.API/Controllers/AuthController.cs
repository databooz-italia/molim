using System.Collections.Generic;
using System.Linq;
using Molim.Backend.API.Auth;
using Molim.Backend.API.BusinessLayer.Services.Authentication;
using Molim.Backend.API.DTO.Auth.Requests;
using Molim.Backend.API.DTO.Auth.Responses;
using Molim.Backend.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Molim.Backend.API.Exceptions.ManagedException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Molim.Backend.API.BusinessLayer.Services;

namespace Molim.Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly BaseService _uow;
        private readonly TokensProvider _tokensProvider;

        public AuthController(ILogger<AuthController> logger, BaseService uow, TokensProvider tokenProvider)
        {
            _logger = logger;
            _uow = uow;
            _tokensProvider = tokenProvider; 
        }

        [HttpPost("login")]        
        public AuthenticationResponse Authenticate([FromBody]AuthenticationRequest request)
        {
            AccountProxy authenticatedAccount = null;
            List<string> permissions = null;

            using (_uow)
            {
                var service = new AccountsService(_uow);
                var permissionsService = new PermissionsService(_uow);

                authenticatedAccount = service.Authenticate(request.Username, request.Password);

                if (authenticatedAccount == null)
                    throw new ManagedException(ExceptionCodes.AuthFail);

                permissions = permissionsService.GetRolePermissions(authenticatedAccount.RoleType)
                    .Select(x => x.ToLower())
                    .ToList();

                _uow.Complete();                
            }

            return new AuthenticationResponse()
            {
                Username = authenticatedAccount.Username,
                Account_ID = authenticatedAccount.ID,
                ShortTermToken = _tokensProvider.ProvideToken(authenticatedAccount.ID, authenticatedAccount.Username, TokensProvider.TokenType.ShortTerm),
                LongTermToken = _tokensProvider.ProvideToken(authenticatedAccount.ID, authenticatedAccount.Username, TokensProvider.TokenType.LongTerm),
                RoleType = authenticatedAccount.RoleType,
                Permissions = permissions,
                ResetPassword = authenticatedAccount.ResetPassword
            };
        }

        [HttpPost("reset-pwd")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {            
            using (_uow)
            {
                var service = new AccountsService(_uow);
                service.ChangePassword(request.OldPassword, request.NewPassword);
                
                _uow.Complete();
            }

            return Ok();
        }
    }
}