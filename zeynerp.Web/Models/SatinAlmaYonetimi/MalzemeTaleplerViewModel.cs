using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Models.SatinAlmaYonetimi
{
    public class MalzemeTaleplerViewModel
    {
        public IReadOnlyList<StokGrupViewModel>? StokGrups { get; set; }
        public IReadOnlyList<StokViewModel>? Stoks { get; set; }
        public IReadOnlyList<StokOzellikViewModel>? StokOzelliks { get; set; }
    }
}