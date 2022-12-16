using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class StileDiVita
    {
        public StileDiVita()
        {
            StiliDiVitaPazienti = new HashSet<StileDiVitaPaziente>();
        }

        public string IdStileDiVita { get; set; }
        public string Descrizione { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<StileDiVitaPaziente> StiliDiVitaPazienti { get; set; }
    }
}
