using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Patologie
{
    public class TipologiaEsameDTO
    {
        public string IdTipologiaEsame { get; set; }
        public string IdPatologia { get; set; }
        public string Descrizione { get; set; }
        public bool RichiedeImmagini { get; set; }
        public IEnumerable<FeatureDTO> Features { get; set; }
    }
}
