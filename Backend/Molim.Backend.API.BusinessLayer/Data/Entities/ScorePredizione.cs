using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class ScorePredizione
    {
        public int IdPredizione { get; set; }
        public string Descrizione { get; set; }
        public string Valore { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Predizione Predizione { get; set; }
    }
}
