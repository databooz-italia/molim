using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Diagnosi.Requests
{
    public class CreaDiagnosiRequest
    {
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }
        public DateTime Date { get; set; }
        public string Esito { get; set; }
    }
}
