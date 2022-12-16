using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public partial class molim_v2Context : DbContext
    {
        public molim_v2Context()
        {
        }

        public molim_v2Context(DbContextOptions<molim_v2Context> options)
            : base(options)
        {

        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Algoritmi> Algoritmi { get; set; }
        public virtual DbSet<Diagnosi> Diagnosi { get; set; }
        public virtual DbSet<Esami> Esami { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<FeaturesEsame> FeaturesEsame { get; set; }
        public virtual DbSet<Immagini> Immagini { get; set; }
        public virtual DbSet<NormalizzazioneFeatures> NormalizzazioneFeatures { get; set; }
        public virtual DbSet<Patologie> Patologie { get; set; }
        public virtual DbSet<Pazienti> Pazienti { get; set; }
        public virtual DbSet<PermessiProfili> PermessiProfili { get; set; }
        public virtual DbSet<Profili> Profili { get; set; }
        public virtual DbSet<RegioniDiInteresse> RegioniDiInteresse { get; set; }
        public virtual DbSet<ScoreDiagnosi> ScoreDiagnosi { get; set; }
        public virtual DbSet<StiliDiVita> StiliDiVita { get; set; }
        public virtual DbSet<StiliDiVitaPazienti> StiliDiVitaPazienti { get; set; }
        public virtual DbSet<TipiEsami> TipiEsami { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost; Database=molim_v2; uid=root; pwd=357246");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.TipoRuolo)
                    .HasName("IX_Accounts_TipoRuolo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cognome).HasMaxLength(250);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.Nome).HasMaxLength(250);

                entity.Property(e => e.TipoRuolo).HasMaxLength(20);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.TipoRuoloNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.TipoRuolo)
                    .HasConstraintName("fk_account_role");
            });

            modelBuilder.Entity<Algoritmi>(entity =>
            {
                entity.ToTable("algoritmi");

                entity.HasIndex(e => new { e.IdTipoEsame, e.IdPatologia })
                    .HasName("fk_algoritmi_tipi_esami1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.EndpointRest)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IdPatologia)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IdTipoEsame)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Algoritmi)
                    .HasForeignKey(d => new { d.IdTipoEsame, d.IdPatologia })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_algoritmi_tipi_esami1");
            });

            modelBuilder.Entity<Diagnosi>(entity =>
            {
                entity.ToTable("diagnosi");

                entity.HasIndex(e => e.IdAlgoritmo)
                    .HasName("fk_diagnosi_algoritmi1_idx");

                entity.HasIndex(e => e.IdEsame)
                    .HasName("fk_diagnosi_esami1_idx");

                entity.HasIndex(e => e.IdRegioneDiInteresse)
                    .HasName("fk_diagnosi_regioni_di_interesse1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.DataStato).HasColumnType("date");

                entity.Property(e => e.Esito).HasMaxLength(500);

                entity.Property(e => e.Stato).HasMaxLength(250);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdAlgoritmoNavigation)
                    .WithMany(p => p.Diagnosi)
                    .HasForeignKey(d => d.IdAlgoritmo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_diagnosi_algoritmi1");

                entity.HasOne(d => d.IdEsameNavigation)
                    .WithMany(p => p.Diagnosi)
                    .HasForeignKey(d => d.IdEsame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_diagnosi_esami1");

                entity.HasOne(d => d.IdRegioneDiInteresseNavigation)
                    .WithMany(p => p.Diagnosi)
                    .HasForeignKey(d => d.IdRegioneDiInteresse)
                    .HasConstraintName("fk_diagnosi_regioni_di_interesse1");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Esami>(entity =>
            {
                entity.HasKey(e => e.IdEsame)
                    .HasName("PRIMARY");

                entity.ToTable("esami");

                entity.HasIndex(e => e.IdPatologia)
                    .HasName("fk_patologia_esami_idx");

                entity.HasIndex(e => e.IdPaziente)
                    .HasName("IX_EsitiTestPazienti_IdPaziente");

                entity.HasIndex(e => e.IdTipoEsame)
                    .HasName("fk_esami_tipi_esami1_idx");

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.IdPatologia)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IdPaziente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdTipoEsame)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdPatologiaNavigation)
                    .WithMany(p => p.Esami)
                    .HasForeignKey(d => d.IdPatologia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patologia_esami");

                entity.HasOne(d => d.IdPazienteNavigation)
                    .WithMany(p => p.Esami)
                    .HasForeignKey(d => d.IdPaziente)
                    .HasConstraintName("FK_EsitiTestPazienti_Pazienti_IdPaziente");
            });

            modelBuilder.Entity<Features>(entity =>
            {
                entity.ToTable("features");

                entity.HasIndex(e => e.IdPatologia)
                    .HasName("IX_ProgettiTest_IdProgetto");

                entity.HasIndex(e => e.IdTipoEsame)
                    .HasName("IX_ProgettiTest_IdTipoTest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdFeature)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdPatologia)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IdTipoEsame)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdPatologiaNavigation)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.IdPatologia)
                    .HasConstraintName("FK_ProgettiTest_Progetti_IdProgetto");
            });

            modelBuilder.Entity<FeaturesEsame>(entity =>
            {
                entity.HasKey(e => new { e.IdEsame, e.IdFeature })
                    .HasName("PRIMARY");

                entity.ToTable("features_esame");

                entity.HasIndex(e => e.IdFeature)
                    .HasName("IX_DettagliEsitiTestPazienti_IdProgettoTest");

                entity.HasIndex(e => e.IdRegioneDiInteresse)
                    .HasName("fk_dettagli_esami_regions_of_interest1_idx");

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.Property(e => e.Valore)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdEsameNavigation)
                    .WithMany(p => p.FeaturesEsame)
                    .HasForeignKey(d => d.IdEsame)
                    .HasConstraintName("FK_DettagliEsitiTestPazienti_EsitiTestPazienti_IdEsitoTestPazie~");

                entity.HasOne(d => d.IdFeatureNavigation)
                    .WithMany(p => p.FeaturesEsame)
                    .HasForeignKey(d => d.IdFeature)
                    .HasConstraintName("FK_DettagliEsitiTestPazienti_ProgettiTest_IdProgettoTest");

                entity.HasOne(d => d.IdRegioneDiInteresseNavigation)
                    .WithMany(p => p.FeaturesEsame)
                    .HasForeignKey(d => d.IdRegioneDiInteresse)
                    .HasConstraintName("fk_dettagli_esami_regions_of_interest1");
            });

            modelBuilder.Entity<Immagini>(entity =>
            {
                entity.ToTable("immagini");

                entity.HasIndex(e => e.IdEsame)
                    .HasName("fk_immagini_esami1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.DataCaricamento).HasColumnType("date");

                entity.Property(e => e.NomeFile)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdEsameNavigation)
                    .WithMany(p => p.Immagini)
                    .HasForeignKey(d => d.IdEsame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_immagini_esami1");
            });

            modelBuilder.Entity<NormalizzazioneFeatures>(entity =>
            {
                entity.ToTable("normalizzazione_features");

                entity.HasIndex(e => e.IdFeature)
                    .HasName("IX_NormalizzazioneRisultatiTest_IdProgettoTest");

                entity.Property(e => e.Avalore)
                    .HasColumnName("AValore")
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.DaValore).HasColumnType("decimal(18,2)");

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdFeatureNavigation)
                    .WithMany(p => p.NormalizzazioneFeatures)
                    .HasForeignKey(d => d.IdFeature)
                    .HasConstraintName("FK_NormalizzazioneRisultatiTest_ProgettiTest_IdProgettoTest");
            });

            modelBuilder.Entity<Patologie>(entity =>
            {
                entity.HasKey(e => e.IdPatologia)
                    .HasName("PRIMARY");

                entity.ToTable("patologie");

                entity.Property(e => e.IdPatologia).HasMaxLength(5);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");
            });

            modelBuilder.Entity<Pazienti>(entity =>
            {
                entity.HasKey(e => e.IdPaziente)
                    .HasName("PRIMARY");

                entity.ToTable("pazienti");

                entity.Property(e => e.IdPaziente).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(500);

                entity.Property(e => e.CodiceFiscale).HasMaxLength(20);

                entity.Property(e => e.CognomePaziente).HasMaxLength(20);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.Indirizzo).HasMaxLength(500);

                entity.Property(e => e.IndirizzoMail).HasMaxLength(500);

                entity.Property(e => e.NomePaziente).HasMaxLength(20);

                entity.Property(e => e.NumeroCellulare).HasMaxLength(20);

                entity.Property(e => e.Sesso).HasMaxLength(10);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");
            });

            modelBuilder.Entity<PermessiProfili>(entity =>
            {
                entity.HasKey(e => new { e.TipoRuolo, e.Permesso })
                    .HasName("PRIMARY");

                entity.ToTable("permessi_profili");

                entity.Property(e => e.TipoRuolo).HasMaxLength(20);

                entity.Property(e => e.Permesso).HasMaxLength(50);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.TipoRuoloNavigation)
                    .WithMany(p => p.PermessiProfili)
                    .HasForeignKey(d => d.TipoRuolo)
                    .HasConstraintName("fk_roles_permissions");
            });

            modelBuilder.Entity<Profili>(entity =>
            {
                entity.HasKey(e => e.Tipo)
                    .HasName("PRIMARY");

                entity.ToTable("profili");

                entity.Property(e => e.Tipo).HasMaxLength(20);

                entity.Property(e => e.Descrizione).HasMaxLength(50);
            });

            modelBuilder.Entity<RegioniDiInteresse>(entity =>
            {
                entity.ToTable("regioni_di_interesse");

                entity.HasIndex(e => e.IdImmagine)
                    .HasName("fk_regions_of_interest_immagini1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.DataCaricamento).HasColumnType("date");

                entity.Property(e => e.NomeFile)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdImmagineNavigation)
                    .WithMany(p => p.RegioniDiInteresse)
                    .HasForeignKey(d => d.IdImmagine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_regions_of_interest_immagini1");
            });

            modelBuilder.Entity<ScoreDiagnosi>(entity =>
            {
                entity.HasKey(e => new { e.Descrizione, e.IdDiagnosi })
                    .HasName("PRIMARY");

                entity.ToTable("score_diagnosi");

                entity.HasIndex(e => e.IdDiagnosi)
                    .HasName("fk_score_diagnosi_diagnosi1_idx");

                entity.Property(e => e.Descrizione).HasMaxLength(200);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.Property(e => e.Valore).HasMaxLength(50);

                entity.HasOne(d => d.IdDiagnosiNavigation)
                    .WithMany(p => p.ScoreDiagnosi)
                    .HasForeignKey(d => d.IdDiagnosi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_score_diagnosi_diagnosi1");
            });

            modelBuilder.Entity<StiliDiVita>(entity =>
            {
                entity.HasKey(e => e.IdStileDiVita)
                    .HasName("PRIMARY");

                entity.ToTable("stili_di_vita");

                entity.Property(e => e.IdStileDiVita).HasMaxLength(5);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");
            });

            modelBuilder.Entity<StiliDiVitaPazienti>(entity =>
            {
                entity.HasKey(e => new { e.IdStileDiVita, e.IdPaziente })
                    .HasName("PRIMARY");

                entity.ToTable("stili_di_vita_pazienti");

                entity.HasIndex(e => e.IdPaziente)
                    .HasName("IX_StiliDiVitaPazienti_IdPaziente");

                entity.Property(e => e.IdStileDiVita).HasMaxLength(5);

                entity.Property(e => e.IdPaziente).HasMaxLength(50);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdPazienteNavigation)
                    .WithMany(p => p.StiliDiVitaPazienti)
                    .HasForeignKey(d => d.IdPaziente)
                    .HasConstraintName("FK_StiliDiVitaPazienti_Pazienti_IdPaziente");

                entity.HasOne(d => d.IdStileDiVitaNavigation)
                    .WithMany(p => p.StiliDiVitaPazienti)
                    .HasForeignKey(d => d.IdStileDiVita)
                    .HasConstraintName("FK_StiliDiVitaPazienti_StiliDiVita_IdStileDiVita");
            });

            modelBuilder.Entity<TipiEsami>(entity =>
            {
                entity.HasKey(e => new { e.IdTipoEsame, e.IdPatologia })
                    .HasName("PRIMARY");

                entity.ToTable("tipi_esami");

                entity.HasIndex(e => e.IdPatologia)
                    .HasName("fk_tipi_esami_patologie1_idx");

                entity.Property(e => e.IdTipoEsame).HasMaxLength(5);

                entity.Property(e => e.IdPatologia).HasMaxLength(5);

                entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RichiedeFeatures).HasColumnType("bit(1)");

                entity.Property(e => e.RichiedeImmagini).HasColumnType("bit(1)");

                entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

                entity.HasOne(d => d.IdPatologiaNavigation)
                    .WithMany(p => p.TipiEsami)
                    .HasForeignKey(d => d.IdPatologia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipi_esami_patologie1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
