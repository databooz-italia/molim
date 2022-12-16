using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Auth.Requests
{
    public class AuthenticationRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
