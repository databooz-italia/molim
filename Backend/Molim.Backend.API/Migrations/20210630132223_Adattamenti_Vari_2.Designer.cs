﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Molim.Backend.API.BusinessLayer.Data;

namespace Molim.Backend.API.Migrations
{
    [DbContext(typeof(MolimDb))]
    [Migration("20210630132223_Adattamenti_Vari_2")]
    partial class Adattamenti_Vari_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cognome")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<bool>("ResetPassword")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TipoRuolo")
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TipoRuolo");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Algoritmo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("EndpointRest")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("IdPatologia")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("IdTipoEsame")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("IdTipoEsame", "IdPatologia")
                        .HasName("fk_algoritmi_tipi_esami1_idx");

                    b.ToTable("algoritmi");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Diagnosi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataStato")
                        .HasColumnType("date");

                    b.Property<string>("Esito")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("IdAlgoritmo")
                        .HasColumnType("int");

                    b.Property<string>("IdPatologia")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("IdPaziente")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Stato")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAlgoritmo")
                        .HasName("fk_diagnosi_algoritmi1_idx");

                    b.HasIndex("IdPatologia")
                        .HasName("fk_diagnosi_patologie1_idx");

                    b.HasIndex("IdPaziente");

                    b.ToTable("diagnosi");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Esame", b =>
                {
                    b.Property<int>("IdEsame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("IdPatologia")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("IdPaziente")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("IdTipoEsame")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("IdEsame")
                        .HasName("PRIMARY");

                    b.HasIndex("IdPatologia")
                        .HasName("fk_patologia_esami_idx");

                    b.HasIndex("IdPaziente")
                        .HasName("IX_EsitiTestPazienti_IdPaziente");

                    b.HasIndex("IdTipoEsame")
                        .HasName("fk_esami_tipi_esami1_idx");

                    b.HasIndex("IdTipoEsame", "IdPatologia");

                    b.ToTable("esami");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFineValidita")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInizioValidita")
                        .HasColumnType("datetime");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("IdFeature")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("IdPatologia")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("IdTipoEsame")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Regex")
                        .HasColumnType("text");

                    b.Property<int>("TipoValore")
                        .HasColumnType("int");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ValoreMax")
                        .HasColumnType("int");

                    b.Property<int?>("ValoreMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPatologia")
                        .HasName("IX_ProgettiTest_IdProgetto");

                    b.HasIndex("IdTipoEsame")
                        .HasName("IX_ProgettiTest_IdTipoTest");

                    b.ToTable("features");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.FeatureAlgoritmo", b =>
                {
                    b.Property<int>("IdAlgoritmo")
                        .HasColumnType("int");

                    b.Property<int>("IdFeature")
                        .HasColumnType("int");

                    b.Property<bool>("Obbligatorio")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdAlgoritmo", "IdFeature");

                    b.HasIndex("IdFeature");

                    b.ToTable("features_algoritmi");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.FeatureEsame", b =>
                {
                    b.Property<int>("IdEsame")
                        .HasColumnType("int");

                    b.Property<int>("IdFeature")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<int?>("IdImmagine")
                        .HasColumnType("int");

                    b.Property<int?>("IdRegioneDiInteresse")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.Property<string>("Valore")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("IdEsame", "IdFeature")
                        .HasName("PRIMARY");

                    b.HasIndex("IdFeature")
                        .HasName("IX_DettagliEsitiTestPazienti_IdProgettoTest");

                    b.HasIndex("IdImmagine");

                    b.HasIndex("IdRegioneDiInteresse")
                        .HasName("fk_dettagli_esami_regions_of_interest1_idx");

                    b.ToTable("features_esame");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Immagine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCaricamento")
                        .HasColumnType("date");

                    b.Property<long>("Dimensione")
                        .HasColumnType("bigint");

                    b.Property<int>("IdEsame")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NomeFile")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEsame")
                        .HasName("fk_immagini_esami1_idx");

                    b.ToTable("immagini");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.NormalizzazioneFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Avalore")
                        .HasColumnName("AValore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("DaValore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdFeature")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.Property<int>("ValoreNormalizzato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFeature")
                        .HasName("IX_NormalizzazioneRisultatiTest_IdProgettoTest");

                    b.ToTable("normalizzazione_features");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Patologia", b =>
                {
                    b.Property<string>("IdPatologia")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("IdPatologia")
                        .HasName("PRIMARY");

                    b.ToTable("patologie");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Paziente", b =>
                {
                    b.Property<string>("IdPaziente")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("AnnoNascita")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("CodiceFiscale")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CognomePaziente")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Education")
                        .HasColumnType("int");

                    b.Property<string>("Indirizzo")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("IndirizzoMail")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NomePaziente")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("NumeroCellulare")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Sesso")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("IdPaziente")
                        .HasName("PRIMARY");

                    b.ToTable("pazienti");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.PermessoProfilo", b =>
                {
                    b.Property<string>("TipoRuolo")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Permesso")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("TipoRuolo", "Permesso")
                        .HasName("PRIMARY");

                    b.ToTable("permessi_profili");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Profilo", b =>
                {
                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Descrizione")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Tipo")
                        .HasName("PRIMARY");

                    b.ToTable("profili");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.RegioneDiInteresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCaricamento")
                        .HasColumnType("date");

                    b.Property<int>("IdImmagine")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NomeFile")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdImmagine")
                        .HasName("fk_regions_of_interest_immagini1_idx");

                    b.ToTable("regioni_di_interesse");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.ScoreDiagnosi", b =>
                {
                    b.Property<string>("Descrizione")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("IdDiagnosi")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.Property<string>("Valore")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Descrizione", "IdDiagnosi")
                        .HasName("PRIMARY");

                    b.HasIndex("IdDiagnosi")
                        .HasName("fk_score_diagnosi_diagnosi1_idx");

                    b.ToTable("score_diagnosi");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.StileDiVita", b =>
                {
                    b.Property<string>("IdStileDiVita")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("IdStileDiVita")
                        .HasName("PRIMARY");

                    b.ToTable("stili_di_vita");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.StileDiVitaPaziente", b =>
                {
                    b.Property<string>("IdStileDiVita")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("IdPaziente")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("IdStileDiVita", "IdPaziente")
                        .HasName("PRIMARY");

                    b.HasIndex("IdPaziente")
                        .HasName("IX_StiliDiVitaPazienti_IdPaziente");

                    b.ToTable("stili_di_vita_pazienti");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.TipoEsame", b =>
                {
                    b.Property<string>("IdTipoEsame")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("IdPatologia")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorAccountId")
                        .HasColumnName("CreatorAccount_ID")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("RichiedeImmagini")
                        .HasColumnType("bit(1)");

                    b.Property<int?>("UpdaterAccountId")
                        .HasColumnName("UpdaterAccount_ID")
                        .HasColumnType("int");

                    b.HasKey("IdTipoEsame", "IdPatologia")
                        .HasName("PRIMARY");

                    b.HasIndex("IdPatologia")
                        .HasName("fk_tipi_esami_patologie1_idx");

                    b.ToTable("tipi_esami");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Account", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Profilo", "Profilo")
                        .WithMany("Accounts")
                        .HasForeignKey("TipoRuolo")
                        .HasConstraintName("fk_account_role");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Algoritmo", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.TipoEsame", "TipoEsame")
                        .WithMany("Algoritmi")
                        .HasForeignKey("IdTipoEsame", "IdPatologia")
                        .HasConstraintName("fk_algoritmi_tipi_esami1")
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Diagnosi", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Algoritmo", "Algoritmo")
                        .WithMany("Diagnosi")
                        .HasForeignKey("IdAlgoritmo")
                        .HasConstraintName("fk_diagnosi_algoritmi1")
                        .IsRequired();

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Patologia", "Patologia")
                        .WithMany("Diagnosi")
                        .HasForeignKey("IdPatologia")
                        .HasConstraintName("fk_diagnosi_patologie1");

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Paziente", "Paziente")
                        .WithMany("Diagnosi")
                        .HasForeignKey("IdPaziente")
                        .HasConstraintName("fk_diagnosi_pazienti1");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Esame", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Patologia", "Patologia")
                        .WithMany("Esami")
                        .HasForeignKey("IdPatologia")
                        .HasConstraintName("fk_patologia_esami")
                        .IsRequired();

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Paziente", "Paziente")
                        .WithMany("Esami")
                        .HasForeignKey("IdPaziente")
                        .HasConstraintName("FK_EsitiTestPazienti_Pazienti_IdPaziente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.TipoEsame", "TipoEsame")
                        .WithMany("Esami")
                        .HasForeignKey("IdTipoEsame", "IdPatologia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Feature", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Patologia", "Patologia")
                        .WithMany("Features")
                        .HasForeignKey("IdPatologia")
                        .HasConstraintName("FK_ProgettiTest_Progetti_IdProgetto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.FeatureAlgoritmo", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Algoritmo", "Algoritmo")
                        .WithMany("Features")
                        .HasForeignKey("IdAlgoritmo")
                        .HasConstraintName("fk_algoritmifeatures_algoritmi")
                        .IsRequired();

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Feature", "Feature")
                        .WithMany("Algoritmi")
                        .HasForeignKey("IdFeature")
                        .HasConstraintName("fk_algoritmifeatures_features")
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.FeatureEsame", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Esame", "Esame")
                        .WithMany("FeaturesEsame")
                        .HasForeignKey("IdEsame")
                        .HasConstraintName("FK_DettagliEsitiTestPazienti_EsitiTestPazienti_IdEsitoTestPazie~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Feature", "Feature")
                        .WithMany("FeaturesEsame")
                        .HasForeignKey("IdFeature")
                        .HasConstraintName("FK_DettagliEsitiTestPazienti_ProgettiTest_IdProgettoTest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Immagine", "Immagine")
                        .WithMany("Features")
                        .HasForeignKey("IdImmagine");

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.RegioneDiInteresse", "RegioneDiInteresse")
                        .WithMany("FeaturesEsame")
                        .HasForeignKey("IdRegioneDiInteresse")
                        .HasConstraintName("fk_dettagli_esami_regions_of_interest1");
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.Immagine", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Esame", "Esame")
                        .WithMany("Immagini")
                        .HasForeignKey("IdEsame")
                        .HasConstraintName("fk_immagini_esami1")
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.NormalizzazioneFeature", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Feature", "Feature")
                        .WithMany("NormalizzazioneFeatures")
                        .HasForeignKey("IdFeature")
                        .HasConstraintName("FK_NormalizzazioneRisultatiTest_ProgettiTest_IdProgettoTest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.PermessoProfilo", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Profilo", "Profilo")
                        .WithMany("PermessiProfili")
                        .HasForeignKey("TipoRuolo")
                        .HasConstraintName("fk_roles_permissions")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.RegioneDiInteresse", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Immagine", "Immagine")
                        .WithMany("RegioniDiInteresse")
                        .HasForeignKey("IdImmagine")
                        .HasConstraintName("fk_regions_of_interest_immagini1")
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.ScoreDiagnosi", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Diagnosi", "Diagnosi")
                        .WithMany("ScoreDiagnosi")
                        .HasForeignKey("IdDiagnosi")
                        .HasConstraintName("fk_score_diagnosi_diagnosi1")
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.StileDiVitaPaziente", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Paziente", "Paziente")
                        .WithMany("StiliDiVitaPazienti")
                        .HasForeignKey("IdPaziente")
                        .HasConstraintName("FK_StiliDiVitaPazienti_Pazienti_IdPaziente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.StileDiVita", "StileDiVita")
                        .WithMany("StiliDiVitaPazienti")
                        .HasForeignKey("IdStileDiVita")
                        .HasConstraintName("FK_StiliDiVitaPazienti_StiliDiVita_IdStileDiVita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Molim.Backend.API.BusinessLayer.Data.Entities.TipoEsame", b =>
                {
                    b.HasOne("Molim.Backend.API.BusinessLayer.Data.Entities.Patologia", "Patologia")
                        .WithMany("TipiEsami")
                        .HasForeignKey("IdPatologia")
                        .HasConstraintName("fk_tipi_esami_patologie1")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
