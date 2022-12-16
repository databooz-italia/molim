using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Immagini
    {
        public Immagini()
        {
            RegioniDiInteresse = new HashSet<RegioniDiInteresse>();
        }

        public int Id { get; set; }
        public int IdEsame { get; set; }
        public string NomeFile { get; set; }
        public DateTime DataCaricamento { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }

        public virtual Esami IdEsameNavigation { get; set; }
        public virtual ICollection<RegioniDiInteresse> RegioniDiInteresse { get; set; }
    }
}
