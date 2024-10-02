using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity_DbFirst_b1.Models
{
    //class đại diện cho sql server
    public partial class ADO_TUTORContext : DbContext
    {
        public ADO_TUTORContext()
        {
        }

        public ADO_TUTORContext(DbContextOptions<ADO_TUTORContext> options)
            : base(options)
        {
        }


        /// <summary>
        /// dbset đóng vai trò là 1 thực thể = đại diện cho bảng ở trong sql
        /// </summary>
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NGUYEN_NGOC_HOA\\HOANN;Database=ADO_TUTOR;Trusted_Connection=True; TrustServerCertificate =True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.ToTable("SinhVien");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
