using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoDeThiThu.Models
{
    //class đại diện cho sql
    public partial class ThiThu_TutorContext : DbContext
    {
        public ThiThu_TutorContext()
        {
        }

        public ThiThu_TutorContext(DbContextOptions<ThiThu_TutorContext> options)
            : base(options)
        {
        }
        //các dbset chính là các bảng ở trong sql
        //vậy nên khi các bạn muốn tương tác vs csl thì phải gọi tên dbset  chứ k phhari class
        public virtual DbSet<Lophoc> Lophocs { get; set; } = null!;
        public virtual DbSet<Sinhvien> Sinhviens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NGUYEN_NGOC_HOA\\HOANN;Database=ThiThu_Tutor ;Trusted_Connection=True; TrustServerCertificate =True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lophoc>(entity =>
            {
                entity.HasKey(e => e.MaLop)
                    .HasName("PK__LOPHOC__3B98D273349D207E");

                entity.ToTable("LOPHOC");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Khoa).HasMaxLength(10);

                entity.Property(e => e.TenLop).HasMaxLength(50);
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.ToTable("SINHVIEN");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nganh)
                    .HasMaxLength(50)
                    .HasColumnName("NGANH");

                entity.Property(e => e.Ten)
                    .HasMaxLength(10)
                    .HasColumnName("TEN");

                entity.Property(e => e.Tuoi).HasColumnName("TUOI");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.Sinhviens)
                    .HasForeignKey(d => d.MaLop)
                    .HasConstraintName("FK__SINHVIEN__MaLop__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
