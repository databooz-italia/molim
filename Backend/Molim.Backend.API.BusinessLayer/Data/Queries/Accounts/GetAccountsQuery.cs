using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Accounts
{
    public static class GetAccountsQuery
    {
        public static IQueryable<Account> GetAccounts(this MolimDb _db, int? account_id, string roleType, bool? deleted = false)
        {
            return _db.Accounts
                .Where(x =>
                                            (!deleted.HasValue || x.Deleted == deleted.Value) &&
                                            (string.IsNullOrEmpty(roleType) || x.Profilo.Tipo == roleType) &&
                                            (!account_id.HasValue || x.Id == account_id)
                      )
                .OrderBy(x => x.Cognome).ThenBy(x => x.Nome);
        }
    }
}
