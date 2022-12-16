using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class PermessiProfili
    {
        public string TipoRuolo { get; set; }
        public string Permesso { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Profili TipoRuoloNavigation { get; set; }
    }
}
