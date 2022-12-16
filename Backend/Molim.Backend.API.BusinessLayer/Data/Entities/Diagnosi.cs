using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public class Diagnosi
    {
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }
        public DateTime Date { get; set; }
        public string Esito { get; set; }

        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public Paziente Paziente { get; set; }
        public Patologia Patologia { get; set; }

        
    }
}
