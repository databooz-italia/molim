using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Esami
{
    public class RegionOfInterestDTO
    {
        public int ID { get; set; }
        public string NomeFile { get; set; }
        public long Dimensione { get; set; }
        public int IdImmagine { get; set; }
        public string NomeFileImmagine { get; set; }
        public IEnumerable<FeatureEsameDTO> Features { get; set; }
    }
}
