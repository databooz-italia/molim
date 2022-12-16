using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class FeaturesEsame
    {
        public int IdEsame { get; set; }
        public int IdFeature { get; set; }
        public int? IdRegioneDiInteresse { get; set; }
        public string Valore { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Esami IdEsameNavigation { get; set; }
        public virtual Features IdFeatureNavigation { get; set; }
        public virtual RegioniDiInteresse IdRegioneDiInteresseNavigation { get; set; }
    }
}
