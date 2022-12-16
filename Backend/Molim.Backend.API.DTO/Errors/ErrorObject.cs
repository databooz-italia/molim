using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Errors
{
    public class ErrorObject
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description{ get; set; }
    }
}
