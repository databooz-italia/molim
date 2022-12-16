using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public class RichiestaEsecuzioneFase
    {
        public int IdRichiestaEsecuzione { get; set; }
        public string IdFase { get; set; }
        public DateTime Data { get; set; }
        public int Ordine { get; set; }
        public string Status { get; set; }
        public DateTime? DataUltimaEsecuzione { get; set; }

        public RichiestaEsecuzione Richiesta { get; set; }
    }
}
