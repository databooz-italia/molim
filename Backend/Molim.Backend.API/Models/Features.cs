using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Features
    {
        public Features()
        {
            FeaturesEsame = new HashSet<FeaturesEsame>();
            NormalizzazioneFeatures = new HashSet<NormalizzazioneFeatures>();
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

        public virtual Patologie IdPatologiaNavigation { get; set; }
        public virtual ICollection<FeaturesEsame> FeaturesEsame { get; set; }
        public virtual ICollection<NormalizzazioneFeatures> NormalizzazioneFeatures { get; set; }
    }
}
