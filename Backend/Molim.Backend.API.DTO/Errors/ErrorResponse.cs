using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Errors
{
    public class ErrorResponse
    {
        [JsonProperty("errors")]
        public List<ErrorObject> Errors { get; set; }
    }
}
