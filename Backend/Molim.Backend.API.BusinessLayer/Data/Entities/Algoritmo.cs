using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Algoritmo
    {
        public Algoritmo()
        {
            Predizioni = new HashSet<Predizione>();
        }

        public int Id { get; set; }
        public string IdTipoEsame { get; set; }
        public string IdPatologia { get; set; }
        public string Tipo { get; set; }
        public string Descrizione { get; set; }
        public string OggettoDiPredizione { get; set; }
        public string EndpointRest { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual TipoEsame TipoEsame { get; set; }
        public virtual ICollection<Predizione> Predizioni { get; set; }
        public virtual ICollection<FeatureAlgoritmo> Features { get; set; }
        public virtual ICollection<RichiestaEsecuzione> RichiesteEsecuzione { get; set; }
    }
}
