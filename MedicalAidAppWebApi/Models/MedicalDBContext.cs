using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<ConnectionRequest> ConnectionRequests { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("user id=MedicalDBAdmin;password=rabinovich490;host=192.168.1.48;database=MedicalDB;character set=utf8", ServerVersion.Parse("10.0.38-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.HasIndex(e => e.UserId, "FK_Appointment_UserID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_UserID");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.ToTable("Connection");

                entity.HasIndex(e => e.CaretakerId, "FK_Connection_CaretakerID");

                entity.HasIndex(e => e.PatientId, "FK_Connection_PatientID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.CaretakerId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("CaretakerID");

                entity.Property(e => e.PatientId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("PatientID");

                entity.HasOne(d => d.Caretaker)
                    .WithMany(p => p.ConnectionCaretakers)
                    .HasForeignKey(d => d.CaretakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Connection_CaretakerID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ConnectionPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Connection_PatientID");
            });

            modelBuilder.Entity<ConnectionRequest>(entity =>
            {
                entity.ToTable("ConnectionRequest");

                entity.HasIndex(e => e.CaretakerId, "FK_ConnectionRequest_CaretakerID");

                entity.HasIndex(e => e.PatientId, "FK_ConnectionRequest_PatientID");

                entity.HasIndex(e => e.RequesterId, "FK_ConnectionRequest_User_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.CaretakerId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("CaretakerID");

                entity.Property(e => e.PatientId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("PatientID");

                entity.Property(e => e.RequesterId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("RequesterID");

                entity.HasOne(d => d.Caretaker)
                    .WithMany(p => p.ConnectionRequestCaretakers)
                    .HasForeignKey(d => d.CaretakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionRequest_CaretakerID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ConnectionRequestPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionRequest_PatientID");

                entity.HasOne(d => d.Requester)
                    .WithMany(p => p.ConnectionRequestRequesters)
                    .HasForeignKey(d => d.RequesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionRequest_User_ID");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.HasIndex(e => e.UserId, "FK_Log_PatientID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(400);

                entity.Property(e => e.Painscale).HasColumnType("tinyint(4) unsigned");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_PatientID");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("Medication");

                entity.HasIndex(e => e.UserId, "FK_Medication_UserID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(400);

                entity.Property(e => e.Dosage)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Time).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Medications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medication_UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
