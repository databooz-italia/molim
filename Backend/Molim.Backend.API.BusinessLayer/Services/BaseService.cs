using Molim.Backend.API.BusinessLayer.Data;
using Microsoft.Extensions.Logging;
using Molim.Backend.API.BusinessLayer.Services.Authentication;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using Molim.Backend.API.BusinessLayer.Interfaces;
using System;
using Molim.Backend.API.BusinessLayer.Exceptions;

namespace Molim.Backend.API.BusinessLayer.Services
{
    public class BaseService : IDisposable
    {
        protected MolimDb _db;
        protected Configuration _conf;
        protected IAuthenticationProvider _auth;
        protected ILogger _logger;

        private bool transactionOwner = false;
        private bool complete = false;

        public BaseService(MolimDb db, Configuration configuration, IAuthenticationProvider authProvider, ILogger logger)
        {
            _db = db;
            _conf = configuration;
            _auth = authProvider;
            _logger = logger;

            if (_db.Database.CurrentTransaction == null)
            {
                _db.Database.AutoTransactionsEnabled = false;
                _db.Database.BeginTransaction();
                transactionOwner = true;
            }
        }

        public BaseService(BaseService b) : this(b._db, b._conf, b._auth, b._logger)
        {

        }

        public Configuration MolimConfiguration => _conf;
        public MolimDb Database => _db;

        private PermissionsService permissionsService = null;

        protected int? GetAccountFilter()
        {
            int? account_id = _auth.GetLoggedAccountId();

            if (!account_id.HasValue)
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString(), "could not find logged account id");

            if (CheckPermissionBase(Data.Entities.Enums.Permissions.Administrator))
                account_id = null;

            return account_id;
        }

        protected bool CheckPermissionBase(Permissions p)
        {
            return true;

            if (permissionsService == null)
                permissionsService = new PermissionsService(this);

            return permissionsService.CheckPermission(p);
        }

        protected bool CheckPermissionBase(string permission)
        {
            if (permissionsService == null)
                permissionsService = new PermissionsService(this);

            return permissionsService.CheckPermission(permission);
        }

        protected bool CheckPermissionBase(Permissions p, params string[] parameters)
        {
            if (permissionsService == null)
                permissionsService = new PermissionsService(this);

            return permissionsService.CheckPermission(p.ToString() + "_" + string.Join("_", parameters));
        }

        public void Complete()
        {
            if (transactionOwner)
                complete = true;
        }

        public void Dispose()
        {
            if (transactionOwner && _db.Database?.CurrentTransaction != null)
            {
                if (complete)
                    _db.Database.CurrentTransaction.Commit();
                else
                    _db.Database.CurrentTransaction.Rollback();
            }
        }
    }
}
