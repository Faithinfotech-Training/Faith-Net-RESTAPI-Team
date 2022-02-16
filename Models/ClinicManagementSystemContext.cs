using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicManagementSystemv2022.Models
{
    public partial class ClinicManagementSystemContext : DbContext
    {
        public ClinicManagementSystemContext()
        {
        }

        public ClinicManagementSystemContext(DbContextOptions<ClinicManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<LabAdvice> LabAdvice { get; set; }
        public virtual DbSet<LabTestCategory> LabTestCategory { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-CE5THMMS\\SQLEXPRESS; Initial Catalog=ClinicManagementSystem; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentFee).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__3A81B327");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__398D8EEE");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.LabFee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MedicineFee).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Bill__PatientId__3D5E1FD2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LabAdvice>(entity =>
            {
                entity.HasKey(e => e.LabTestId)
                    .HasName("PK__LabAdvic__64D339255A6ACFD2");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.LabAdvice)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__LabAdvice__Presc__36B12243");

                entity.HasOne(d => d.TestCategory)
                    .WithMany(p => p.LabAdvice)
                    .HasForeignKey(d => d.TestCategoryId)
                    .HasConstraintName("FK__LabAdvice__TestC__35BCFE0A");
            });

            modelBuilder.Entity<LabTestCategory>(entity =>
            {
                entity.HasKey(e => e.TestCategoryId)
                    .HasName("PK__LabTestC__2CE372FD1B3229A5");

                entity.Property(e => e.TestCategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LabFee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValueRange)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfExpiry).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineCharge).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicinePrescription>(entity =>
            {
                entity.HasKey(e => e.PrescriptionMedId)
                    .HasName("PK__Medicine__2B34041B2F428639");

                entity.Property(e => e.Dosage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__MedicineP__Medic__30F848ED");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicineP__Presc__300424B4");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.Property(e => e.PrescriptionDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Prescript__Docto__2C3393D0");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Prescript__Patie__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
