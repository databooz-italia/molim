using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Profilo
    {
        public Profilo()
        {
            Accounts = new HashSet<Account>();
            PermessiProfili = new HashSet<PermessoProfilo>();
        }

        public string Tipo { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<PermessoProfilo> PermessiProfili { get; set; }
    }
}
