using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Accounts.Responses
{
    public class GetAccountsResponse
    {
        public IEnumerable<AccountDTO> Accounts { get; set; }
    }


}
