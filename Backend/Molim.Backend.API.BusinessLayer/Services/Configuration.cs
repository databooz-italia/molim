using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services
{
    public class Configuration
    {
        public string NotificationImplementorType { get; set; }
        public string RootPath { get; set; }        
        public string CryptoSecret { get; set; }     
        public string Version { get; set; }
    }
}
