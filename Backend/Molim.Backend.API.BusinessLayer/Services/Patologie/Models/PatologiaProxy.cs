using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Patologie.Models
{
    public class PatologiaProxy
    {
        public string ID { get; set; }
        public string Descrizione { get; set; }

        public IEnumerable<TipologiaEsameProxy> TipiEsami { get; set; }
    }
}
