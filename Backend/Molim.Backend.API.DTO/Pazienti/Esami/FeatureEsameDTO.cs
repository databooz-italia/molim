using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Esami
{
    public class FeatureEsameDTO
    {
        public string IdFeature { get; set; }
        public string Descrizione { get; set; }

        public int? IdImmagine { get; set; }
        public int? IdROI { get; set; }

        public DateTime? DataInizioValidita { get; set; }
        public DateTime? DataFineValidita { get; set; }
        public object Valore { get; set; }
        public string TipoValore { get; set; }
    }
}
