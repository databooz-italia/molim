using Microsoft.AspNetCore.Http;
using Molim.Backend.API.BusinessLayer.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace Molim.Backend.API.Auth
{
    public class AuthenticationProvider : HttpContextAccessor, IAuthenticationProvider
    {        
        public AuthenticationProvider()
        {

        }

        public int? GetLoggedAccountId()
        {
            int? loggedAccountId = null;

            try
            {
                loggedAccountId = int.Parse(
                    (this.HttpContext.User.Identity as ClaimsIdentity)
                    .Claims
                    .Single(c => c.Type == ClaimTypes.NameIdentifier)
                    .Value);
            }
            catch
            {
                loggedAccountId = null;
            }

            return loggedAccountId;
        }

        public string GetLoggedAccountUsername()
        {
            string loggedUsername = null;

            try
            {
                loggedUsername = (
                    (this.HttpContext.User.Identity as ClaimsIdentity)
                    .Claims
                    .Single(c => c.Type == ClaimTypes.Name)
                    .Value);
            }
            catch
            {
                loggedUsername = null;
            }

            return loggedUsername;
        }

        public string GetMachineID()
        {
            return "Machine Info";
        }
    }
}