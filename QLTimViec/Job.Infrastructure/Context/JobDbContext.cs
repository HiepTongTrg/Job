using Job.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Infrastructure.Context
{
    public class JobDbContext : DbContext
    {
        public JobDbContext()
        {

        }
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {

        }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<NhaTuyenDung> NhaTuyenDungs { get; set; }
        public virtual DbSet<UngVien> UngViens { get; set; }
        public virtual DbSet<XinViec> XinViecs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongViec>(e =>
            {
                e.ToTable("CongViec");
                e.HasKey(e => e.ID);
                e.Property(e => e.ID)
                .IsRequired();

                e.Property(e => e.NhaTuyenDungID)
                .IsRequired();

                e.Property(e => e.NgayDang)
                .IsRequired()
                .HasColumnType("date");

                e.Property(e => e.TenCongViec)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.Luong)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.MoTa)
                .IsRequired()
                .HasMaxLength(200);

                e.Property(e => e.LoaiCV)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.Avatar)
                .IsRequired()
                .HasMaxLength(100);
            });
            modelBuilder.Entity<NhaTuyenDung>(e =>
            {
                e.ToTable("NhaTuyenDung");
                e.HasKey(e => e.ID);
                e.Property(e => e.ID)
                .IsRequired();

                e.Property(e => e.TenCongTy)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.DiaChi)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.DienThoai)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.PassWord)
                .IsRequired()
                .HasMaxLength(100);
            });
            modelBuilder.Entity<UngVien>(e => 
            {
                e.ToTable("UngVien");
                e.HasKey(e => e.ID);
                e.Property(e => e.ID)
                .IsRequired();

                e.Property(e => e.TenUngVien)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.DiaChi)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.DienThoai)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.PassWord)
                .IsRequired()
                .HasMaxLength(100);
            });
            modelBuilder.Entity<XinViec>(e =>
            {
                e.ToTable("XinViec");
                e.HasKey(e => e.ID);
                e.Property(e => e.ID)
                .IsRequired();

                e.Property(e => e.CongViecID)
                .IsRequired();
                e.Property(e => e.UngVienID)
                .IsRequired();
                e.Property(e => e.CV)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(e => e.TrangThai)
                .IsRequired()
                .HasColumnType("int");

                e.Property(e => e.MoTa)
                .IsRequired()
                .HasMaxLength(200);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
