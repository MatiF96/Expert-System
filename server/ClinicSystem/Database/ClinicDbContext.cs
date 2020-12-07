using System;
using ClinicSystem.DTO;
using ClinicSystem.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClinicSystem.Database
{
    public partial class ClinicDbContext : DbContext
    {
        public ClinicDbContext()
        {
        }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountBirthdate)
                    .HasColumnType("date")
                    .HasColumnName("account_birthdate");

                entity.Property(e => e.AccountFullname).HasColumnName("account_fullname");

                entity.Property(e => e.AccountLogin)
                    .IsRequired()
                    .HasColumnName("account_login");

                entity.Property(e => e.AccountPassword)
                    .IsRequired()
                    .HasColumnName("account_password");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasColumnName("account_type");
                entity.HasData(new Account
                {
                    AccountId = -1,
                    AccountType = UserRole.Admin,
                    AccountLogin = "admin123",
                    AccountFullname = new RSAHandler().Encrypt("Litościwie nam panujący Pan Admin"),
                    AccountPassword = new RSAHandler().Encrypt("admin123")
                });
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.HasIndex(e => e.AppointmentDoctorId, "fki_doctor_id");

                entity.HasIndex(e => e.AppointmentPatientId, "fki_patient_id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.AppointmentDoctorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("appointment_doctor_id");

                entity.Property(e => e.AppointmentPatientId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("appointment_patient_id");

                entity.HasOne(d => d.AppointmentDoctor)
                    .WithMany(p => p.AppointmentAppointmentDoctors)
                    .HasForeignKey(d => d.AppointmentDoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_id");

                entity.HasOne(d => d.AppointmentPatient)
                    .WithMany(p => p.AppointmentAppointmentPatients)
                    .HasForeignKey(d => d.AppointmentPatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
