using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Models.SatinalmaYonetimi
{
    public class MalzemeTalepViewModel
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
        public string? Boyut1 { get; set; }
        public string? Boyut2 { get; set; }
        public string? Boyut3 { get; set; }
        public string? Boyut4 { get; set; }
        public string? Kg { get; set; }
        public string? M2 { get; set; }
        public string? Mm { get; set; }
        public string? M { get; set; }
        public IReadOnlyList<StokGrupViewModel>? StokGrups { get; set; }
        public IReadOnlyList<StokViewModel>? Stoks { get; set; }
        public IReadOnlyList<StokOzellikViewModel>? StokOzelliks { get; set; }
    }
}