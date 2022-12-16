using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Algoritmi
    {
        public Algoritmi()
        {
            Diagnosi = new HashSet<Diagnosi>();
        }

        public int Id { get; set; }
        public string IdTipoEsame { get; set; }
        public string IdPatologia { get; set; }
        public string Tipo { get; set; }
        public string Descrizione { get; set; }
        public string EndpointRest { get; set; }

        public virtual TipiEsami IdNavigation { get; set; }
        public virtual ICollection<Diagnosi> Diagnosi { get; set; }
    }
}
