using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class TipoEsame
    {
        public TipoEsame()
        {
            Algoritmi = new HashSet<Algoritmo>();
        }

        public string IdTipoEsame { get; set; }
        public string IdPatologia { get; set; }
        public string Descrizione { get; set; }
        public bool RichiedeImmagini { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Patologia Patologia { get; set; }
        public virtual ICollection<Algoritmo> Algoritmi { get; set; }
        public virtual ICollection<Esame> Esami { get; set; }
        public virtual ICollection<Feature> Features { get; set; }
    }
}
