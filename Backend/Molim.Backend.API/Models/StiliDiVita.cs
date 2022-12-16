using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class StiliDiVita
    {
        public StiliDiVita()
        {
            StiliDiVitaPazienti = new HashSet<StiliDiVitaPazienti>();
        }

        public string IdStileDiVita { get; set; }
        public string Descrizione { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual ICollection<StiliDiVitaPazienti> StiliDiVitaPazienti { get; set; }
    }
}
