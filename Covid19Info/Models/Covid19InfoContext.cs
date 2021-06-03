using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Covid19Info.Models
{
    public partial class Covid19InfoContext : DbContext
    {
        public Covid19InfoContext()
        {
        }

        public Covid19InfoContext(DbContextOptions<Covid19InfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admini> Adminis { get; set; }
        public virtual DbSet<BrojZarazenihOsoba> BrojZarazenihOsobas { get; set; }
        public virtual DbSet<Komentari> Komentaris { get; set; }
        public virtual DbSet<Korisnici> Korisnicis { get; set; }
        public virtual DbSet<Slajder> Slajders { get; set; }
        public virtual DbSet<Vesti> Vestis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DLHDK3B\\MSSQLSERVER01;Database=Covid19Info;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admini>(entity =>
            {
                entity.ToTable("Admini");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ime).HasMaxLength(100);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(100);

                entity.Property(e => e.Lozinka).HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(100);
            });

            modelBuilder.Entity<BrojZarazenihOsoba>(entity =>
            {
                entity.ToTable("BrojZarazenihOsoba");

                entity.Property(e => e.DatumTestiranja).HasColumnType("datetime");

                entity.Property(e => e.DeoNaKojiSePodaciOdnose).HasMaxLength(200);
            });

            modelBuilder.Entity<Komentari>(entity =>
            {
                entity.ToTable("Komentari");

                entity.Property(e => e.KorisnickoIme).HasMaxLength(100);
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.ToTable("Korisnici");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ime).HasMaxLength(100);
            });

            modelBuilder.Entity<Slajder>(entity =>
            {
                entity.ToTable("Slajder");
            });

            modelBuilder.Entity<Vesti>(entity =>
            {
                entity.ToTable("Vesti");

                entity.Property(e => e.Datum).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
