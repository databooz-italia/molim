using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Patologia
    {
        public Patologia()
        {
            Esami = new HashSet<Esame>();
            Features = new HashSet<Feature>();
            TipiEsami = new HashSet<TipoEsame>();
        }

        public string IdPatologia { get; set; }
        public string Descrizione { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<Esame> Esami { get; set; }
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<TipoEsame> TipiEsami { get; set; }
        public virtual ICollection<Predizione> Predizioni { get; set; }
        public virtual ICollection<Diagnosi> Diagnosi { get; set; }
    }
}
