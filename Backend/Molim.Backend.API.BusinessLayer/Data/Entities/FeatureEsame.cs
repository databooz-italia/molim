using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class FeatureEsame
    {
        public int ID { get; set; }
        public int IdEsame { get; set; }
        public int IdFeature { get; set; }
        public int? IdImmagine { get; set; }
        public int? IdRegioneDiInteresse { get; set; }
        public string Valore { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Esame Esame { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual RegioneDiInteresse RegioneDiInteresse { get; set; }
        public virtual Immagine Immagine { get; set; }
    }
}
