using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Molim.Backend.API.BusinessLayer.Services;

namespace Molim.Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly ILogger<VersionController> _logger;
        private readonly Configuration _configuration;

        public VersionController(ILogger<VersionController> logger, Configuration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet()]        
        public string GetVersion()
        {
            _logger.LogInformation("requestiong app version");

            return _configuration.Version;
        }
    }
}