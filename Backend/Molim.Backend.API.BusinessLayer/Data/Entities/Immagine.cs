using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Immagine
    {
        public Immagine()
        {
            RegioniDiInteresse = new HashSet<RegioneDiInteresse>();
        }

        public int Id { get; set; }
        public int IdEsame { get; set; }
        public string NomeFile { get; set; }
        public DateTime DataCaricamento { get; set; }
        public long Dimensione { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Esame Esame { get; set; }
        public virtual ICollection<RegioneDiInteresse> RegioniDiInteresse { get; set; }
        public virtual ICollection<FeatureEsame> Features { get; set; } 
        public virtual ICollection<RichiestaEsecuzione> RichiesteEsecuzione { get; set; }
    }
}
