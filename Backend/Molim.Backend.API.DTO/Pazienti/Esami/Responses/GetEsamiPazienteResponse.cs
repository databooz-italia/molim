using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Esami.Responses
{
    public class GetEsamiPazienteResponse
    {
        public Dictionary<string, IEnumerable<EsamePazienteDTO>> EsamiPaziente { get; set; }
    }
}
