using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class MedicalDBContext : DbContext
    {
        public MedicalDBContext()
        {
        }

        public MedicalDBContext(DbContextOptions<MedicalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Caretaker> Caretaker { get; set; }
        public virtual DbSet<Connection> Connection { get; set; }
        public virtual DbSet<ConnectionRequest> ConnectionRequest { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Medication> Medication { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("user id=MedicalDBAdmin;password=rabinovich490;host=192.168.1.48;database=MedicalDB;character set=utf8", x => x.ServerVersion("10.0.38-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasIndex(e => e.PatientId)
                    .HasName("FK_Appointment_Patient_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(400)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Patient_ID");
            });

            modelBuilder.Entity<Caretaker>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(320)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(11)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.HasIndex(e => e.CaretakerId)
                    .HasName("FK_PatientCaretaker_Caretaker_ID");

                entity.HasIndex(e => e.PatientId)
                    .HasName("FK_PatientCaretaker_Patient_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CaretakerId)
                    .HasColumnName("CaretakerID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasColumnType("int(11) unsigned");

                entity.HasOne(d => d.Caretaker)
                    .WithMany(p => p.Connection)
                    .HasForeignKey(d => d.CaretakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientCaretaker_Caretaker_ID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Connection)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientCaretaker_Patient_ID");
            });

            modelBuilder.Entity<ConnectionRequest>(entity =>
            {
                entity.HasIndex(e => e.CaretakerId)
                    .HasName("FK_ConnectionRequest_Caretaker_ID");

                entity.HasIndex(e => e.PatientId)
                    .HasName("FK_ConnectionRequest_Patient_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CaretakerId)
                    .HasColumnName("CaretakerID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.RequesterId)
                    .HasColumnName("RequesterID")
                    .HasColumnType("int(11) unsigned");

                entity.HasOne(d => d.Caretaker)
                    .WithMany(p => p.ConnectionRequest)
                    .HasForeignKey(d => d.CaretakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionRequest_Caretaker_ID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ConnectionRequest)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionRequest_Patient_ID");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasIndex(e => e.PatientId)
                    .HasName("FK_Log_Patient_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(400)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PainScale).HasColumnType("tinyint(4) unsigned");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_Patient_ID");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.HasIndex(e => e.PatientId)
                    .HasName("FK_Medication_Patient_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(400)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Dosage)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Time)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Medication)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medication_Patient_ID");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(320)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(11)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
