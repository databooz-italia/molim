using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Auth.Responses
{
    public class AuthenticationResponse
    {
        [JsonProperty("shortTermToken")]
        public string ShortTermToken { get; set; }

        [JsonProperty("longTermToken")]
        public string LongTermToken { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("account_id")]
        public int Account_ID { get; set; }        

        [JsonProperty("role")]
        public string RoleType { get; set; }

        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }

        [JsonProperty("resetPassword")]
        public bool ResetPassword { get; set; }
    }
}
