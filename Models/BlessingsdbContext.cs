using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blessings.ViewModel;
using Blessings.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class BlessingsdbContext : IdentityDbContext
    {
        public BlessingsdbContext()
        {
        }

        public BlessingsdbContext(DbContextOptions<BlessingsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Child> Child { get; set; }
        public virtual DbSet<Emergency> Emergency { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Medical> Medical { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("BlessingsDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.ChildFirstName).IsUnicode(false);

                entity.Property(e => e.ChildLastName).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ContactPhone).IsUnicode(false);

                entity.Property(e => e.FatherFirstName).IsUnicode(false);

                entity.Property(e => e.FatherLastName).IsUnicode(false);

                entity.Property(e => e.MotherFirstName).IsUnicode(false);

                entity.Property(e => e.MotherLastName).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Street).IsUnicode(false);
            });

            modelBuilder.Entity<Emergency>(entity =>
            {
                entity.Property(e => e.EmergencyContactFirstName).IsUnicode(false);

                entity.Property(e => e.EmergencyContactLastName).IsUnicode(false);

                entity.Property(e => e.EmergencyContactPhone).IsUnicode(false);

                entity.Property(e => e.Relationship).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Emergency)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emergency_Child");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.Course).IsUnicode(false);

                entity.Property(e => e.RoomNo).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Child");
            });

            modelBuilder.Entity<Medical>(entity =>
            {
                entity.Property(e => e.ChildsDoctorFirstName).IsUnicode(false);

                entity.Property(e => e.ChildsDoctorLastName).IsUnicode(false);

                entity.Property(e => e.ChildsDoctorPhone).IsUnicode(false);

                entity.Property(e => e.DiaetryRestriction).IsUnicode(false);

                entity.Property(e => e.MedicalIssue).IsUnicode(false);

                entity.Property(e => e.PersonToContactFirstName).IsUnicode(false);

                entity.Property(e => e.PersonToContactLastName).IsUnicode(false);

                entity.Property(e => e.PersonToContactPhone).IsUnicode(false);

                entity.Property(e => e.RegularlyUsedHospitalName).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Medical)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medical_Child");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PayerName).IsUnicode(false);

                entity.Property(e => e.PaymentType).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Child");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Room).IsUnicode(false);

                entity.Property(e => e.StaffFirstName).IsUnicode(false);

                entity.Property(e => e.StaffLastName).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Street).IsUnicode(false);

                entity.Property(e => e.Zipcode).IsUnicode(false);
            });

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Blessings.ViewModel.EnrollmentViewModel> EnrollmentViewModel { get; set; }

        public DbSet<Blessings.Models.Room> Room { get; set; }
        public DbSet<Blessings.Models.CourseFees> CourseFees { get; set; }
        public DbSet<Blessings.Models.ChildLog> ChildLog { get; set; }
        public DbSet<Blessings.Models.StaffLog> StaffLog { get; set; }

        public DbSet<Blessings.Models.ChildActivity> ChildActivity { get; set; }

        public DbSet<Blessings.ViewModel.PaymentVM> PaymentVM { get; set; }

        public DbSet<Blessings.Models.ProjectRole> ProjectRole { get; set; }

        public DbSet<Blessings.ViewModel.DashBoradViewModel> DashBoradViewModel { get; set; }

        public DbSet<Blessings.ViewModel.Sign_InOutChildrenVM> Sign_InOutChildrenVM { get; set; }

        public DbSet<Blessings.Models.ReportsList> ReportsList { get; set; }
    }
}
