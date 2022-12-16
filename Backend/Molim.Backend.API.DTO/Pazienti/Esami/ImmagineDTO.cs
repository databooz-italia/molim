using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Esami
{
    public class ImmagineDTO
    {
        public int ID { get; set; }
        public int IdEsame { get; set; }
        public string Nome { get; set; }
        public long Dimensione { get; set; }
        public DateTime DataCaricamento { get; set; }

        public IEnumerable<FeatureEsameDTO> Features { get; set; }
        public IEnumerable<RegionOfInterestDTO> RegioniDiInteresse { get; set; }
    }
}
