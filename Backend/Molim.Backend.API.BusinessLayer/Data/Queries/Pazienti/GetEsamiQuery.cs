using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Queries.Accounts
{
    public static class GetEsamiQuery
    {
        public static IQueryable<EsameImmaginiFeatures> GetEsamiPaziente(this MolimDb _db, string idPaziente)
        {
            return /*_db.Esami
                .Where(x => x.IdPaziente == idPaziente)
                .OrderBy(x => x.Patologia.Descrizione);*/
                from esame in _db.Esami
                join patologia in _db.Patologie on esame.IdPatologia equals patologia.IdPatologia
                join paziente in _db.Pazienti on esame.IdPaziente equals paziente.IdPaziente
                join tipoEsame in _db.TipiEsami on new { esame.IdTipoEsame, esame.IdPatologia } equals new { tipoEsame.IdTipoEsame, tipoEsame.IdPatologia }

                join featureEsame_left in _db.FeaturesEsame on esame.IdEsame equals featureEsame_left.IdEsame into featureEsame_left_t
                from featureEsame in featureEsame_left_t.DefaultIfEmpty()

                join feature_left in _db.Features on featureEsame.IdFeature equals feature_left.Id into feature_left_t
                from feature in feature_left_t.DefaultIfEmpty()

                where esame.IdPaziente == idPaziente

                select new EsameImmaginiFeatures()
                {
                    IdEsame = esame.IdEsame,
                    IdFeature = feature.IdFeature,
                    Data = esame.Data,
                    DescrizioneFeature = feature.Descrizione,
                    DescrizionePatologia = patologia.Descrizione,
                    IdPaziente = paziente.IdPaziente,
                    RichiedeImmagini = tipoEsame.RichiedeImmagini,
                    IdImmagine = featureEsame.IdImmagine,
                    DescrizionePaziente = paziente.CognomePaziente + " " + paziente.NomePaziente,
                    DescrizioneTipoEsame = tipoEsame.Descrizione,
                    IdPatologia = patologia.IdPatologia,
                    IdTipoEsame = tipoEsame.IdTipoEsame,                    
                    TipoValoreFeature = feature.TipoValore.ToString(),
                    ValoreFeature = featureEsame.Valore
                };
        }

        public class EsameImmaginiFeatures
        {
            public int IdEsame { get; set; }
            public string IdTipoEsame { get; set; }
            public string IdPaziente { get; set; }
            public string IdPatologia { get; set; }            
            public DateTime Data { get; set; }
            public string DescrizionePaziente { get; set; }
            public string DescrizionePatologia { get; set; }
            public string DescrizioneTipoEsame { get; set; }
            public bool RichiedeImmagini { get; set; }            
            public string IdFeature { get; set; }
            public string DescrizioneFeature { get; set; }
            public string TipoValoreFeature { get; set; }
            public int? IdImmagine { get; set; }
            public string ValoreFeature { get; set; }            
        }
    }
}
