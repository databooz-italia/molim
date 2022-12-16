using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Paziente
    {
        public Paziente()
        {
            Esami = new HashSet<Esame>();
            StiliDiVitaPazienti = new HashSet<StileDiVitaPaziente>();
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
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Esame> Esami { get; set; }
        public virtual ICollection<StileDiVitaPaziente> StiliDiVitaPazienti { get; set; }
        public virtual ICollection<Predizione> Predizioni { get; set; }
        public virtual ICollection<Diagnosi> Diagnosi { get; set; }
        public virtual ICollection<RichiestaEsecuzione> RichiesteEsecuzione { get; set; }
    }
}
