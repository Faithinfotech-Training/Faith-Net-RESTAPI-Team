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
        public virtual DbSet<Doctor> Doctor { get; set; }
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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-67C0LP2; Initial Catalog=ClinicManagementSystem; Integrated security=True");
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
                    .HasConstraintName("FK__Appointme__Docto__24927208");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__239E4DCF");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.LabFee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MedicineFee).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Bill__PatientId__276EDEB3");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DoctorNavigation)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Doctor__DoctorId__2B3F6F97");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LabAdvice>(entity =>
            {
                entity.HasKey(e => e.LabTestId)
                    .HasName("PK__LabAdvic__64D33925E6702D0B");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.LabAdvice)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__LabAdvice__Presc__20C1E124");

                entity.HasOne(d => d.TestCategory)
                    .WithMany(p => p.LabAdvice)
                    .HasForeignKey(d => d.TestCategoryId)
                    .HasConstraintName("FK__LabAdvice__TestC__1FCDBCEB");
            });

            modelBuilder.Entity<LabTestCategory>(entity =>
            {
                entity.HasKey(e => e.TestCategoryId)
                    .HasName("PK__LabTestC__2CE372FD236E0EAE");

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
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineFee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicinePrescription>(entity =>
            {
                entity.HasKey(e => e.PrescriptionMedId)
                    .HasName("PK__Medicine__2B34041BFA988A7F");

                entity.Property(e => e.Dosage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__MedicineP__Medic__1B0907CE");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicineP__Presc__1A14E395");
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
                    .HasConstraintName("FK__Prescript__Docto__164452B1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Prescript__Patie__173876EA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
