using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Predizioni.Responses
{
    public class GetPredizioniPazienteResponse
    {
        public Dictionary<string, IEnumerable<PredizioneDTO>> PredizioniPaziente { get; set; }
    }
}
