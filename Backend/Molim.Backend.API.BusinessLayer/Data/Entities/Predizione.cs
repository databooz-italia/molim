using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Predizione
    {
        public Predizione()
        {
            ScoreDiagnosi = new HashSet<ScorePredizione>();
        }

        public int Id { get; set; }
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }        
        public int IdAlgoritmo { get; set; }
        public string Stato { get; set; }
        public DateTime? DataStato { get; set; }
        public string Esito { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Algoritmo Algoritmo { get; set; }
        public virtual Patologia Patologia { get; set; }
        public virtual Paziente Paziente { get; set; }
        public virtual ICollection<ScorePredizione> ScoreDiagnosi { get; set; }
    }
}
