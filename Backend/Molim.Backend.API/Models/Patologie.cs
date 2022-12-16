using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Patologie
    {
        public Patologie()
        {
            Esami = new HashSet<Esami>();
            Features = new HashSet<Features>();
            TipiEsami = new HashSet<TipiEsami>();
        }

        public string IdPatologia { get; set; }
        public string Descrizione { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual ICollection<Esami> Esami { get; set; }
        public virtual ICollection<Features> Features { get; set; }
        public virtual ICollection<TipiEsami> TipiEsami { get; set; }
    }
}
