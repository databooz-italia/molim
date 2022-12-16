using Molim.Backend.API.BusinessLayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Patologie
{
    public static class GetPatologieQuery
    {
        public static IQueryable<Patologia> GetPatologie(this MolimDb _db)
        {
            return _db.Patologie
                .OrderBy(x => x.IdPatologia);
        }
    }
}
