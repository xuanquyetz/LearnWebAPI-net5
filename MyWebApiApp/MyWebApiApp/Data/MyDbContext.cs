using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> HangChiTiets { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(q => q.MaDonHang);
                e.Property(q => q.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(q => q.SoDienThoai).IsRequired().HasMaxLength(11);
                e.Property(q => q.NguoiNhanHang).HasMaxLength(100);
                e.Property(q=>q.DiaChiGiao).HasMaxLength(250);
            });
            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("DonHangChiTiet");
                entity.HasKey(e => new { e.MaDonHang, e.MaHangHoa });

                entity.HasOne(e => e.DonHang).WithMany(e => e.DonHangChiTiets).HasForeignKey(e => e.MaDonHang)
                .HasConstraintName("FK_DonHangChiTiet_DonHang");
                entity.HasOne(e => e.HangHoa).WithMany(e => e.DonHangChiTiets).HasForeignKey(e => e.MaHangHoa)
                .HasConstraintName("FK_DonHangChiTiet_HangHoa");
            });

        }
    }
}
