using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class StiliDiVitaPazienti
    {
        public string IdPaziente { get; set; }
        public string IdStileDiVita { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Pazienti IdPazienteNavigation { get; set; }
        public virtual StiliDiVita IdStileDiVitaNavigation { get; set; }
    }
}
