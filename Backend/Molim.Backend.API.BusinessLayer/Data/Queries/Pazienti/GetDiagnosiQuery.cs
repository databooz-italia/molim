using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Accounts
{
    public static class GetDiagnosiQuery
    {
        public static IQueryable<Diagnosi> GetDiagnosi(this MolimDb _db, string idPaziente)
        {
            return _db.Diagnosi.Where(x => x.IdPaziente == idPaziente);            
        }
    }
}
