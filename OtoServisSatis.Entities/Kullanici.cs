using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }

        public int RolId{ get; set; }

        [StringLength(50)]
        public string  Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }

        public bool Aktif { get; set; }

        public DateTime? KayitTarihi { get; set; } = DateTime.Now;

        public Rol? Rol { get; set; }
    }
}
