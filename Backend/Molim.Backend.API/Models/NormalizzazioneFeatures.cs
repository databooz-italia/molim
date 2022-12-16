using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class NormalizzazioneFeature
    {
        public int Id { get; set; }
        public int IdFeature { get; set; }
        public decimal DaValore { get; set; }
        public decimal Avalore { get; set; }
        public int ValoreNormalizzato { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Features IdFeatureNavigation { get; set; }
    }
}
