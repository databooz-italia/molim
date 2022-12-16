using System;
using System.Collections.Generic;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class Account
    {
        public int Id { get; set; }
        public string TipoRuolo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public long Version { get; set; }
        public int? CreatorAccountId { get; set; }
        public int? UpdaterAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool ResetPassword { get; set; }
        public bool Deleted { get; set; }

        public virtual Profilo Profilo { get; set; }
    }
}
