using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class RegioneDiInteresse
    {
        public RegioneDiInteresse()
        {
            FeaturesEsame = new HashSet<FeatureEsame>();
        }

        public int Id { get; set; }
        public int IdImmagine { get; set; }
        public string NomeFile { get; set; }
        public DateTime DataCaricamento { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Immagine Immagine { get; set; }
        public virtual ICollection<FeatureEsame> FeaturesEsame { get; set; }
        public virtual ICollection<RichiestaEsecuzione> RichiesteEsecuzione { get; set; }
    }
}
