using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Models.SatinalmaYonetimi
{
    public class MalzemeTalepleriDetayViewModel
    {
        public IReadOnlyList<MalzemeTalepleriViewModel>? MalzemeTalepleriViewModels { get; set; }
        public IReadOnlyList<ParaBirimViewModel>? ParaBirimViewModels { get; set; }
        public IReadOnlyList<KDVViewModel>? KDVViewModels { get; set; }
        public IReadOnlyList<OdemeVadeViewModel>? OdemeVadeViewModels { get; set; }
        public IReadOnlyList<BirimViewModel>? BirimViewModels { get; set; }
        public IReadOnlyList<TeslimatAdresViewModel>? TeslimatAdresViewModels { get; set; }
    }
}