using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Accounts
{
    public static class GetDettagliEsameQuery
    {
        public static IQueryable<FeatureEsame> GetDettagliEsitiTestPazienti(this MolimDb _db, int idEsame)
        {
            return _db.FeaturesEsame
                .Where(x => x.IdEsame == idEsame)
                .OrderBy(x => x.Feature.IdFeature);
        }
    }
}
