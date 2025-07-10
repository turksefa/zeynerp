using zeynerp.Core.Entities;
using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Application.DTOs.SatinalmaYonetimi
{
    public class MalzemeTalepDto
    {
        public int Id { get; set; }
        public int Birim { get; set; }
        public int StokGrupId { get; set; }
        public StokGrup? StokGrup { get; set; }
        public int StokId { get; set; }
        public Stok? Stok { get; set; }
        public int StokOzellikId { get; set; }
        public StokOzellik? StokOzellik { get; set; }
        public string? Aciklama { get; set; }
        public double Boyut1 { get; set; }
        public double Boyut2 { get; set; }
        public double Boyut3 { get; set; }
        public double Boyut4 { get; set; }
        public double Kg { get; set; }
        public double M2 { get; set; }
        public double Mm { get; set; }
        public double M { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Durum { get; set; }
    }
}