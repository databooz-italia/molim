using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Diagnosi.Responses
{
    public class GetDiagnosiPazienteResponse
    {
        public Dictionary<string, IEnumerable<DiagnosiDTO>> DiagnosiPaziente { get; set; }
    }
}
