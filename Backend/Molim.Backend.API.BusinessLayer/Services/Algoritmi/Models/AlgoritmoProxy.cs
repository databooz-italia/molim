using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Algoritmi.Models
{
    public class AlgoritmoProxy
    {
        public int Id { get; set; }
        public string IdPatologia { get; set; }
        public string IdTipoEsame { get; set; }
        public string Descrizione { get; set; }
        public string EndpointRest { get; set; }
        public string Tipo { get; set; }
        public string OggettoDiPredizione { get; set; }

        public IEnumerable<FeatureAlgoritmoProxy> Features { get; set; }
    }
}
