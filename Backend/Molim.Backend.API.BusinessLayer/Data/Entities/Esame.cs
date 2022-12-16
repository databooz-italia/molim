using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Esame
    {
        public Esame()
        {
            FeaturesEsame = new HashSet<FeatureEsame>();
            Immagini = new HashSet<Immagine>();
        }

        public int IdEsame { get; set; }
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }
        public string IdTipoEsame { get; set; }
        public DateTime Data { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }


        public virtual Patologia Patologia { get; set; }
        public virtual Paziente Paziente { get; set; }
        public virtual TipoEsame TipoEsame { get; set; }
        public virtual ICollection<FeatureEsame> FeaturesEsame { get; set; }
        public virtual ICollection<Immagine> Immagini { get; set; }
    }
}
