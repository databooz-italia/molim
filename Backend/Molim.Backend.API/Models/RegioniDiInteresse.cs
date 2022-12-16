using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class RegioniDiInteresse
    {
        public RegioniDiInteresse()
        {
            Diagnosi = new HashSet<Diagnosi>();
            FeaturesEsame = new HashSet<FeaturesEsame>();
        }

        public int Id { get; set; }
        public int IdImmagine { get; set; }
        public string NomeFile { get; set; }
        public DateTime DataCaricamento { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Immagini IdImmagineNavigation { get; set; }
        public virtual ICollection<Diagnosi> Diagnosi { get; set; }
        public virtual ICollection<FeaturesEsame> FeaturesEsame { get; set; }
    }
}
