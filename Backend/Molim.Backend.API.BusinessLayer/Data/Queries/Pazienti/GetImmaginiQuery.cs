using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Accounts
{
    public static class GetImmaginiQuery
    {
        public static IQueryable<Immagine> GetImmagini(this MolimDb _db, string idPaziente)
        {
            return _db.Immagini.Where(x => x.Esame.IdPaziente == idPaziente).OrderBy(x => x.Id);
        }
    }
}
