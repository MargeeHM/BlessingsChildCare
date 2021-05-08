using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class BlessingsdbContext : DbContext
    {
        public BlessingsdbContext()
        {
        }

        public BlessingsdbContext(DbContextOptions<BlessingsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseFees> CourseFees { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("BlessingsDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseFees>(entity =>
            {
                entity.Property(e => e.CoursefeesId).HasColumnName("coursefees_id");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasColumnName("course")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnName("enrollmentDate")
                    .HasColumnType("date");

                entity.Property(e => e.RoomNo)
                    .IsRequired()
                    .HasColumnName("roomNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.PayerName)
                    .IsRequired()
                    .HasColumnName("payerName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("paymentDate")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasColumnName("paymentType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
