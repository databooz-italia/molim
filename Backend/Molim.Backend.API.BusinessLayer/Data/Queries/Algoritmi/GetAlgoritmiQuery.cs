using Molim.Backend.API.BusinessLayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Patologie
{
    public static class GetAlgoritmiQuery
    {
        public static IQueryable<Algoritmo> GetAlgoritmi(this MolimDb _db)
        {
            return _db.Algoritmi
                .OrderBy(x => x.Id);
        }
    }
}
