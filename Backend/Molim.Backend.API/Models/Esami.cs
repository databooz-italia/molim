using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Esami
    {
        public Esami()
        {
            Diagnosi = new HashSet<Diagnosi>();
            FeaturesEsame = new HashSet<FeaturesEsame>();
            Immagini = new HashSet<Immagini>();
        }

        public int IdEsame { get; set; }
        public string IdPaziente { get; set; }
        public string IdPatologia { get; set; }
        public string IdTipoEsame { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Patologie IdPatologiaNavigation { get; set; }
        public virtual Pazienti IdPazienteNavigation { get; set; }
        public virtual ICollection<Diagnosi> Diagnosi { get; set; }
        public virtual ICollection<FeaturesEsame> FeaturesEsame { get; set; }
        public virtual ICollection<Immagini> Immagini { get; set; }
    }
}
