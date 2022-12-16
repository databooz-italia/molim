using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Molim.Backend.API.BusinessLayer.Exceptions;
using Molim.Backend.API.BusinessLayer.Interfaces;

namespace Molim.Backend.API.BusinessLayer.Services.Authentication
{
    public class PermissionsService : BaseService
    {        
        public PermissionsService(MolimDb db, Configuration conf, IAuthenticationProvider auth, ILogger logger) : base(db, conf, auth, logger)
        {
            
        }

        public PermissionsService(BaseService b) : base(b)
        {

        }

        public bool CheckPermission(Permissions p)
        {
            return CheckPermission(p.ToString());
        }        

        public bool CheckPermission(string p)
        {
            if (_auth?.GetLoggedAccountId() == null)
                return false;

            return (from rp in Database.PermessiProfili
                    join r in Database.Profili on rp.TipoRuolo equals r.Tipo
                    join a in Database.Accounts on r.Tipo equals a.TipoRuolo
                    where a.Id == _auth.GetLoggedAccountId().Value && rp.Permesso == p
                    select true).Any();
        }

        public List<string> GetRolePermissions(string roleType)
        {
            return (from rp in Database.PermessiProfili
                    where rp.TipoRuolo == roleType
                    select rp.Permesso)
                    .ToList();
        }
    }
}
