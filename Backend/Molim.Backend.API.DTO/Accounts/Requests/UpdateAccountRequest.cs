using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Accounts.Requests
{
    public class UpdateAccountRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Bookings { get; set; }
        public DateTime? BookingsToDate { get; set; }
        public int? AccountType_ID { get; set; }
        public long Version { get; set; }
    }
}
