using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Patologie.Models
{
    public class TipologiaEsameProxy
    {
        public string IdTipologiaEsame { get; set; }
        public string IdPatologia { get; set; }
        public string Descrizione { get; set; }
        public bool RichiedeImmagini { get; set; }
        public IEnumerable<FeatureProxy> Features { get; set; }
    }
}
