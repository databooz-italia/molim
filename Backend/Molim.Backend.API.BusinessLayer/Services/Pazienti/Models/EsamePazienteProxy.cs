using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Pazienti.Models
{
    public class EsamePazienteProxy
    {
        public int IdEsame { get; set; }
        public DateTime Data { get; set; }
        public bool RichiedeImmagini { get; set; }
        public string IdPaziente { get; set; }
        public string DescrizionePaziente { get; set; }
        public string IdPatologia { get; set; }
        public string DescrizionePatologia { get; set; }
        public string IdTipoEsame { get; set; }
        public string DescrizioneTipoEsame { get; set; }

        public IEnumerable<ImmagineProxy> Immagini { get; set; }
        public IEnumerable<FeatureEsameProxy> Features { get; set; }
    }
}
