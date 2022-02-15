using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicManagementSystemv2022.Models
{
    public partial class DemoExperionDec2021DBContext : DbContext
    {
        public DemoExperionDec2021DBContext()
        {
        }

        public DemoExperionDec2021DBContext(DbContextOptions<DemoExperionDec2021DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-67C0LP2; Initial Catalog=DemoExperionDec2021DB; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfJoining).HasColumnType("date");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__267ABA7A");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblRole");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblUser");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Userpassword)
                    .HasColumnName("userpassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
