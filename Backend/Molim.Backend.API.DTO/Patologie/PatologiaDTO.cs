using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Patologie
{
    public class PatologiaDTO
    { 
        public string ID { get; set; }
        public string Descrizione { get; set; }

        public IEnumerable<TipologiaEsameDTO> TipiEsami { get; set; }
    }
}
