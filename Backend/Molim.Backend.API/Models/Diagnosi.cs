using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Diagnosi
    {
        public Diagnosi()
        {
            ScoreDiagnosi = new HashSet<ScoreDiagnosi>();
        }

        public int Id { get; set; }
        public int IdEsame { get; set; }
        public int? IdRegioneDiInteresse { get; set; }
        public int IdAlgoritmo { get; set; }
        public string Stato { get; set; }
        public DateTime? DataStato { get; set; }
        public string Esito { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Algoritmi IdAlgoritmoNavigation { get; set; }
        public virtual Esami IdEsameNavigation { get; set; }
        public virtual RegioniDiInteresse IdRegioneDiInteresseNavigation { get; set; }
        public virtual ICollection<ScoreDiagnosi> ScoreDiagnosi { get; set; }
    }
}
