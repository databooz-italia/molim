using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Algoritmi
{
    public class AlgoritmoDTO
    {
        public int Id { get; set; }
        public string IdPatologia { get; set; }
        public string IdTipoEsame { get; set; }
        public string Descrizione { get; set; }
        public string EndpointRest { get; set; }
        public string Tipo { get; set; }
        public string OggettoDiPredizione { get; set; }

        public IEnumerable<FeatureAlgoritmoDTO> Features { get; set; }
    }
}
