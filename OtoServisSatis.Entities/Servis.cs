using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Servis : IEntity
    {
        public int Id { get; set; }       

        public string AracSorunu { get; set; }

        public  decimal ServisUcreti { get; set; }

        public string? YapılanIslemler { get; set; }

        public bool GarantiKapsaminda { get; set; }

        [StringLength(15)]
        public string AracPlaka { get; set; }

        [StringLength(50)]
        public string Marka { get; set; }

        [StringLength(50)]
        public string? Model { get; set; }

        [StringLength(50)]
        public string? KasaTipi { get; set; }

        [StringLength(50)]
        public string? SaseNo { get; set; }

        public string? Notlar { get; set; }

        public DateTime GirisTarihi { get; set; }

        public DateTime CikisTarihi { get; set; }
    }
}
