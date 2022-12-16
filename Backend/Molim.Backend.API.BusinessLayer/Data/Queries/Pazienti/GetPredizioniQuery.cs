using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Accounts
{
    public static class GetPredizioniQuery
    {
        public static IQueryable<Predizione> GetPredizioni(this MolimDb _db, string idPaziente)
        {
            return _db.Predizioni.Where(x => x.IdPaziente == idPaziente);            
        }

        public class PredizioneConValore
        {
            public int ID { get; set; }
            public string IdPaziente { get; set; }
            public string IdPatologia { get; set; }
            public int IdAlgoritmo { get; set; }
            public DateTime DataRichiesta { get; set; }
            public string DescrizionePatologia { get; set; }
            public string DescrizioneAlgoritmo { get; set; }
            public string DescrizionePaziente { get; set; }
            public string Esito { get; set; }
            public string EsitoPredizione { get; set; }
            public string IdFeature { get; set; }
            public string DescrizioneFeature { get; set; }
            public string Valore { get; set; }
            public string TipoValore { get; set; }
        }
    }
}
