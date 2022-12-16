using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Feature
    {
        public Feature()
        {
            FeaturesEsame = new HashSet<FeatureEsame>();
            NormalizzazioneFeatures = new HashSet<NormalizzazioneFeature>();
        }

        public int Id { get; set; }
        public string IdFeature { get; set; }
        public string IdPatologia { get; set; }
        public int TipoValore { get; set; }
        public string IdTipoEsame { get; set; }
        public string Descrizione { get; set; }
        public int? ValoreMin { get; set; }
        public int? ValoreMax { get; set; }
        public string Regex { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime? DataFineValidita { get; set; }
        public DateTime? DataInizioValidita { get; set; }

        public virtual Patologia Patologia { get; set; }
        public virtual TipoEsame TipoEsame { get; set; }
        public virtual ICollection<FeatureEsame> FeaturesEsame { get; set; }
        public virtual ICollection<NormalizzazioneFeature> NormalizzazioneFeatures { get; set; }
        public virtual ICollection<FeatureAlgoritmo> Algoritmi { get; set; }
    }
}
