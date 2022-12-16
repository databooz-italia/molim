using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Auth.Requests
{
    public class ResetPasswordRequest
    {
        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }
}
