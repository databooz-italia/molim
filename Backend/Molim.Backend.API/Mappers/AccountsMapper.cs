using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Molim.Backend.API.DTO;
using Molim.Backend.API.DTO.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Molim.Backend.API.Mappers
{
    public static class AccountsMapper
    {
        public static AccountDTO Map(AccountProxy account)
        {
            if (account == null)
                return null;

            return new AccountDTO()
            {
                Account_ID = account.ID,
                AccountType_ID = account.AccountType_ID,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Username = account.Username,
                AvailableBookings = account.AvailableBookings,
                AvailableBookingsToDate = account.AvailableBookingsToDate,
                Version = account.Version,
                RoleType = account.RoleType,
                RoleDescription = account.RoleDescription
            };
        }
    }
}
