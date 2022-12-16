using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Profili
    {
        public Profili()
        {
            Accounts = new HashSet<Accounts>();
            PermessiProfili = new HashSet<PermessiProfili>();
        }

        public string Tipo { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<PermessiProfili> PermessiProfili { get; set; }
    }
}
