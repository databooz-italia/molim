using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Molim.Backend.API.Utils.Cryptography;
using Molim.Backend.API.BusinessLayer.Interfaces;
using Molim.Backend.API.BusinessLayer.Data.Queries.Accounts;

namespace Molim.Backend.API.BusinessLayer.Services.Authentication
{
    public class AccountsService : BaseService
    {

        public AccountsService(MolimDb db, Configuration conf, IAuthenticationProvider auth, ILogger logger) : base(db, conf, auth, logger)
        {

        }

        public AccountsService(BaseService b) : base(b)
        {

        }

        public IEnumerable<AccountProxy> GetAccounts(string role)
        {
            _logger.LogInformation("Requesting accounts by role {0}", role);

            if (!CheckPermissionBase(Permissions.ReadAccounts))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            int? accountFilter = GetAccountFilter();

            return Database
                .GetAccounts(accountFilter, role)
                .Select(x => new AccountProxy()
                {
                    ID = x.Id,
                    Username = x.Username,
                    FirstName = x.Nome,
                    LastName = x.Cognome,
                    Version = x.Version,
                    RoleType = x.TipoRuolo,
                    RoleDescription = x.Profilo.Descrizione
                })
                .ToList();
        }

        public AccountProxy Authenticate(string username, string password)
        {
            _logger.LogInformation("Authenticating username {0}", username);

            if (username == null || password == null)
                throw new BusinessManagedException(ErrorCodes.BadRequest.ToString(), "username or password empty");

            var cryptor = new Utils.Cryptography.Cryptor(MolimConfiguration.CryptoSecret);
            var hashedPassword = cryptor.Hash(password);

            return Database.Accounts
                .Where(x =>
                        x.Username.ToLower() == username.ToLower() &&
                        (x.Password == null || x.Password == hashedPassword)
                       )
                .AsNoTracking()
                .Select(x => new AccountProxy()
                {
                    FirstName = x.Nome,
                    ID = x.Id,
                    LastName = x.Cognome,
                    Username = x.Username,
                    RoleType = x.TipoRuolo,
                    RoleDescription = x.Profilo.Descrizione,
                    ResetPassword = x.ResetPassword
                }).SingleOrDefault();
        }

        public Account CreateAccount(string username, string firstName, string lastName, string password, int? bookings, DateTime? bookingsToDate, string roleType, int? accountType_id)
        {
            _logger.LogInformation("Creating user {0} {1} with username {2}", lastName, firstName, username);

            if (username == null || password == null)
                throw new BusinessManagedException(ErrorCodes.BadRequest.ToString());

            var role_id = Database.Profili.SingleOrDefault(x => x.Tipo == roleType)?.Tipo;

            if (string.IsNullOrEmpty(role_id))
                throw new BusinessManagedException(ErrorCodes.NotFound.ToString(), $"could not find default role for type {roleType.ToString()}");

            if (!CheckPermissionBase(Permissions.CreateAccounts))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var existingAccount = Database.Accounts.SingleOrDefault(x => x.Username == username);

            if (existingAccount != null)
                throw new BusinessManagedException(ErrorCodes.DuplicateUsername.ToString());

            var cryptor = new Utils.Cryptography.Cryptor(MolimConfiguration.CryptoSecret);
            var hashedPassword = cryptor.Hash(password);

            var account = Database.Accounts.Add(new Account()
            {
                Username = username,
                Cognome = lastName,
                Nome = firstName,
                Password = hashedPassword,
                TipoRuolo = role_id,
                ResetPassword = true
            });

            Database.SaveChanges();

            return account.Entity;
        }

        public Account UpdateAccount(int id, string username, string firstName, string lastName, string password, int? bookings, DateTime? bookingsToDate, int? accountType_id, long version)
        {
            _logger.LogInformation("Updating user {0} {1} with username {2}", lastName, firstName, username);

            if (username == null)
                throw new BusinessManagedException(ErrorCodes.BadRequest.ToString(), "username is empty");

            var toUpdate = Database.Accounts.SingleOrDefault(x => x.Id == id);

            if (toUpdate == null)
                throw new BusinessManagedException(ErrorCodes.NotFound.ToString(), "didnt find account to update");

            if (!CheckPermissionBase(Permissions.UpdateAccounts))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString(), "role not enabled for this roles updates");

            toUpdate.Username = username;
            toUpdate.Nome = firstName;
            toUpdate.Cognome = lastName;
 
            toUpdate.Version = version;

            if (!string.IsNullOrEmpty(password))
            {
                var cryptor = new Utils.Cryptography.Cryptor(MolimConfiguration.CryptoSecret);
                toUpdate.Password = cryptor.Hash(password);

                toUpdate.ResetPassword = true;
            }

            Database.SaveChanges();

            return toUpdate;
        }

        public void DeleteAccount(int id)
        {            
            var toUpdate = Database.Accounts.SingleOrDefault(x => x.Id == id);

            if (toUpdate == null)
                throw new BusinessManagedException(ErrorCodes.NotFound.ToString(), "didnt find account to update");

            _logger.LogInformation("Deleting user {0}", toUpdate.Username);

            if (!CheckPermissionBase(Permissions.DeleteAccounts))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString(), "role not enabled for this roles deletion");

            toUpdate.Deleted = true;

            Database.SaveChanges();           
        }
        public void ChangePassword(string oldPassword, string newPassowrd)
        {            
            int? loggedAccount_id = _auth.GetLoggedAccountId();

            if (!loggedAccount_id.HasValue)
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var account = Database.Accounts.SingleOrDefault(x => x.Id == loggedAccount_id.Value);

            var oldPasswordAuthenticatedAccount = Authenticate(account.Username, oldPassword);

            if (oldPasswordAuthenticatedAccount == null || oldPasswordAuthenticatedAccount.ID != loggedAccount_id.Value)
                throw new BusinessManagedException(ErrorCodes.AuthFail.ToString());

            _logger.LogInformation("Changing user {0} password", oldPasswordAuthenticatedAccount.Username);

            var c = new Cryptor(MolimConfiguration.CryptoSecret);
            account.Password = c.Hash(newPassowrd);

            account.ResetPassword = false;

            Database.SaveChanges();
        }
    }
}
