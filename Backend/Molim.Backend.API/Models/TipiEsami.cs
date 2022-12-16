using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class TipiEsami
    {
        public TipiEsami()
        {
            Algoritmi = new HashSet<Algoritmi>();
        }

        public string IdTipoEsame { get; set; }
        public string IdPatologia { get; set; }
        public string Descrizione { get; set; }
        public bool RichiedeImmagini { get; set; }
        public bool RichiedeFeatures { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Patologie IdPatologiaNavigation { get; set; }
        public virtual ICollection<Algoritmi> Algoritmi { get; set; }
    }
}
