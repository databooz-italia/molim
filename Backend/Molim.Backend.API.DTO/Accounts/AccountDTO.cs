using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Accounts
{
    public class AccountDTO
    {
        public int Account_ID { get; set; }
        public int? AccountType_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string RoleType { get; set; }
        public string RoleDescription { get; set; }
        public int? AvailableBookings { get; set; }
        public DateTime? AvailableBookingsToDate { get; set; }
        public long Version { get; set; }
    }
}
