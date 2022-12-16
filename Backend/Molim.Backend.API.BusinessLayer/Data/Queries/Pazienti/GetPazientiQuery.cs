using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Accounts
{
    public static class GetPazientiQuery
    {
        public static IQueryable<Paziente> GetPazienti(this MolimDb _db)
        {
            return _db.Pazienti.OrderBy(x => x.CognomePaziente).ThenBy(x => x.NomePaziente);
        }
    }
}
