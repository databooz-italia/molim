using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Molim.Backend.API.BusinessLayer.Interfaces;

namespace Molim.Backend.API.BusinessLayer.Data
{
    public class MolimDb : DbContext
    {
        protected IAuthenticationProvider _authProvider;
        public int? LoggedAccount_ID
        {
            get
            {
                return _authProvider?.GetLoggedAccountId();
            }
        }

        public MolimDb(DbContextOptions options, IAuthenticationProvider authProvider) : base(options)
        {
            _authProvider = authProvider;
        }

        public override int SaveChanges()
        {
            DateTime now = DateTime.Now;

            foreach (var trackedEntry in ChangeTracker.Entries().Where(e => e.State != EntityState.Detached && e.State != EntityState.Unchanged))
            {

                #region TRACKING

                if (trackedEntry.Entity is ITrackedObject)
                {
                    if (trackedEntry.State == EntityState.Added)
                    {
                        (trackedEntry.Entity as ITrackedObject).CreationDate = now;
                        (trackedEntry.Entity as ITrackedObject).CreatorAccount_ID = _authProvider?.GetLoggedAccountId();
                    }

                    (trackedEntry.Entity as ITrackedObject).LastUpdateDate = now;
                    (trackedEntry.Entity as ITrackedObject).UpdaterAccount_ID = _authProvider?.GetLoggedAccountId();
                }

                #endregion

                #region CONCURRENCY

                if (trackedEntry.Entity is IConcurrencyObject)
                    (trackedEntry.Entity as IConcurrencyObject).Version++;

                #endregion

            }

            return base.SaveChanges();
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<FeatureAlgoritmo> FeaturesAlgoritmi { get; set; }
        public virtual DbSet<Algoritmo> Algoritmi { get; set; }
        public virtual DbSet<Predizione> Predizioni { get; set; }
        public virtual DbSet<Diagnosi> Diagnosi { get; set; }
        public virtual DbSet<Esame> Esami { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<FeatureEsame> FeaturesEsame { get; set; }
        public virtual DbSet<Immagine> Immagini { get; set; }
        public virtual DbSet<NormalizzazioneFeature> NormalizzazioneFeatures { get; set; }
        public virtual DbSet<Patologia> Patologie { get; set; }
        public virtual DbSet<Paziente> Pazienti { get; set; }
        public virtual DbSet<PermessoProfilo> PermessiProfili { get; set; }
        public virtual DbSet<Profilo> Profili { get; set; }
        public virtual DbSet<RegioneDiInteresse> RegioniDiInteresse { get; set; }
        public virtual DbSet<ScorePredizione> ScorePredizioni { get; set; }
        public virtual DbSet<StileDiVita> StiliDiVita { get; set; }
        public virtual DbSet<StileDiVitaPaziente> StiliDiVitaPazienti { get; set; }
        public virtual DbSet<TipoEsame> TipiEsami { get; set; }
        public virtual DbSet<EsecutoreRichiesta> EsecutoriRichieste { get; set; }
        public virtual DbSet<RichiestaEsecuzione> RichiesteEsecuzione { get; set; }
        public virtual DbSet<RichiestaEsecuzioneFase> RichiestaEsecuzioneFasi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MolimDb).Assembly);
        }
    }
}
