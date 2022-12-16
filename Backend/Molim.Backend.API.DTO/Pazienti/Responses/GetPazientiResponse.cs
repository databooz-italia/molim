using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Responses
{
    public class GetPazientiResponse
    {
        public IEnumerable<PazienteDTO> Pazienti { get; set; }
    }
}
