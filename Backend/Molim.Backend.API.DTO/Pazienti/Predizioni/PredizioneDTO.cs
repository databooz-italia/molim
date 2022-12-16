using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Predizioni
{
    public class PredizioneDTO
    {
        public int ID { get; set; }
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }
        public int IdAlgoritmo { get; set; }
        public DateTime DataRichiesta { get; set; }
        public string DescrizionePatologia { get; set; }
        public string DescrizioneAlgoritmo { get; set; }
        public string DescrizionePaziente { get; set; }
        public string EsitoPredizione { get; set; }
        public string Esito { get; set; }        
    }
}
