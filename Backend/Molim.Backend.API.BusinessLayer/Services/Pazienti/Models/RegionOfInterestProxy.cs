using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Pazienti.Models
{
    public class RegionOfInterestProxy
    {
        public int ID { get; set; }
        public string NomeFile { get; set; }
        public long Dimensione { get; set; }
        public int IdImmagine { get; set; }
        public string NomeFileImmagine { get; set; }
        public IEnumerable<FeatureEsameProxy> Features { get; set; }
    }
}
