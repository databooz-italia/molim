using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public class RichiestaEsecuzione
    {
        public int ID { get; set; }
        public int IdAlgoritmo { get; set; }
        public int IdImmagine { get; set; }
        public int? IdRegioneDiInteresse { get; set; }
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }
        public string Parametri { get; set; }
        public DateTime Data { get; set; }
        public string IdEsecutore { get; set; }
        public string Risultato { get; set; }
        public DateTime? DataCompletamento { get; set; }

        public Algoritmo Algoritmo { get; set; }
        public Paziente Paziente { get; set; }
        public EsecutoreRichiesta Esecutore { get; set; }
        public Immagine Immagine { get; set; }
        public RegioneDiInteresse RegioneDiInteresse { get; set; }
        public virtual ICollection<RichiestaEsecuzioneFase> Fasi { get; set; }
    }
}
