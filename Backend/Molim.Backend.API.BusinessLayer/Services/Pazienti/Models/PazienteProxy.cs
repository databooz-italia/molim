﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Pazienti.Models
{
    public class PazienteProxy
    {
        public string IdPaziente { get; set; }
        public string NomePaziente { get; set; }
        public string CognomePaziente { get; set; }
        public int? AnnoNascita { get; set; }
        public string Sesso { get; set; }
        public string City { get; set; }
        public string CodiceFiscale { get; set; }
        public string Indirizzo { get; set; }
        public string IndirizzoMail { get; set; }
        public string NumeroCellulare { get; set; }
        public int? Education { get; set; }
    }
}
