using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Pazienti.Models
{
    public class FeatureEsameProxy
    {
        public string IdFeature { get; set; }
        public string Descrizione { get; set; }
        public DateTime? DataInizioValidita { get; set; }
        public DateTime? DataFineValidita { get; set; }
        public object Valore { get; set; }
        public string TipoValore { get; set; }
    }
}
