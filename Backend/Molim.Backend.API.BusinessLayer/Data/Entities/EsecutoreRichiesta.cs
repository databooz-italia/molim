using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public class EsecutoreRichiesta
    {
        public string ID { get; set; }
        public bool Abilitato { get; set; }

        public virtual ICollection<RichiestaEsecuzione> RichiesteEsecuzione { get; set; }
    }
}
