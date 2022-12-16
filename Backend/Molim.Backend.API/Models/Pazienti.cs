using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Pazienti
    {
        public Pazienti()
        {
            Esami = new HashSet<Esami>();
            StiliDiVitaPazienti = new HashSet<StiliDiVitaPazienti>();
        }

        public string IdPaziente { get; set; }
        public string NomePaziente { get; set; }
        public string CognomePaziente { get; set; }
        public int? AnnoNascita { get; set; }
        public string Sesso { get; set; }
        public string City { get; set; }
        public string CodiceFiscale { get; set; }
        public string Indirizzo { get; set; }
        public string IndirizzoMail { get; set; }
        public string NumeroCellulare { get; set; }
        public int? Education { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Esami> Esami { get; set; }
        public virtual ICollection<StiliDiVitaPazienti> StiliDiVitaPazienti { get; set; }
    }
}
