using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Pazienti.Models
{
    public class DiagnosiProxy
    {
        public int ID { get; set; }
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }        
        public DateTime Data { get; set; }
        public string DescrizionePatologia { get; set; }
        public string DescrizionePaziente { get; set; }
        public string Esito { get; set; }
    }
}
