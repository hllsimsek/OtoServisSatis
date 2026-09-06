using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OtoServisSatis.Entities;

namespace OtoServisSatis.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }

        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<Kullanici> Kullanici { get; set; }

        public DbSet<Satis> Satislar { get; set; }

        public DbSet<Marka> Markalar { get; set; }

        public DbSet<Rol> Roller { get; set; }

        public DbSet<Servis> Servisler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(LocalDB)\MSSQLLocalDB; database=DB_OtoServisSatis; integrated security=true; TrustServerCertificate=true;");

            // uyarıları devre dışı bırakmak için ConfigureWarnings kullanıyoruz.
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API kullanarak entitylerin propertylerini yapılandırıyoruz. - Data Annotations yerine Fluent API kullanıyoruz.
            modelBuilder.Entity<Marka>().Property(m => m.Ad).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Ad).IsRequired().HasColumnType("varchar(50)");

            // Seed data ekliyoruz. Migration sırasında bu veriler otomatik olarak eklenir.
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Ad = "Admin"
            });

            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Ad = "Admin",
                Soyad = "Admin",
                Aktif = true,
                KayitTarihi = DateTime.Now,
                Email = "admin@otoservissatis.com",
                KullaniciAdi = "admin",
                Sifre = "123456",
                RolId = 1,
                Telefon = "1234567890"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
