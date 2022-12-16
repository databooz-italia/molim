using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class ScoreDiagnosi
    {
        public int IdDiagnosi { get; set; }
        public string Descrizione { get; set; }
        public string Valore { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Diagnosi IdDiagnosiNavigation { get; set; }
    }
}
