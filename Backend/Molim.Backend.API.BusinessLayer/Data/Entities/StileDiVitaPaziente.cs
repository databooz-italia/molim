using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class StileDiVitaPaziente
    {
        public string IdPaziente { get; set; }
        public string IdStileDiVita { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Paziente Paziente { get; set; }
        public virtual StileDiVita StileDiVita { get; set; }
    }
}
