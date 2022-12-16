using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Patologie.Models
{
    public class FeatureProxy
    {
        public int Id { get; set; }
        public string IdFeature { get; set; }
        public string IdPatologia { get; set; }
        public string IdTipologiaEsame { get; set; }
        public string DescrizionePatologia { get; set; }
        public string DescrizioneTipologiaEsame { get; set; }
        public string TipoValore { get; set; }
        public int? ValoreMinimo { get; set; }
        public int? ValoreMassimo { get; set; }
        public string Regex { get; set; }
        public Dictionary<string, string> ValoriAmmessi { get; set; }
    }
}
