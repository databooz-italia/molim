using Microsoft.AspNetCore.Http;
using Molim.Backend.API.BusinessLayer.Interfaces;
using Serilog.Context;
using System;
using System.Threading.Tasks;

namespace Molim.Backend.API.Middlewares
{
    public class SerilogUserDataMiddleware
    {
        readonly RequestDelegate _next;
        readonly IAuthenticationProvider _authProvider;

        public SerilogUserDataMiddleware(RequestDelegate next, IAuthenticationProvider authProvider)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            _authProvider = authProvider;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var userName = _authProvider.GetLoggedAccountUsername();

            // Push the user name into the log context so that it is included in all log entries
            using (LogContext.PushProperty("Username", userName))
            {
                await _next(httpContext);
            }
        }
    }
}
