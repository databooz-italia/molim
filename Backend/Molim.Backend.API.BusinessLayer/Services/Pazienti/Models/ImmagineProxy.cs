using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Pazienti.Models
{
    public class ImmagineProxy
    {
        public int ID { get; set; }
        public int IdEsame { get; set; }
        public string Nome { get; set; }
        public long Dimensione { get; set; }
        public DateTime DataCaricamento { get; set; }

        public IEnumerable<FeatureEsameProxy> Features { get; set; }
        public IEnumerable<RegionOfInterestProxy> RegioniDiInteresse { get; set; }
    }
}
