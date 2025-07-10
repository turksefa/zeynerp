using zeynerp.Core.Entities.SatinalmaYonetimi;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Models.SatinalmaYonetimi
{
    public class MalzemeTalepleriViewModel
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public Cari? Cari { get; set; }
        public int CariYetkiliId { get; set; }
        public CariYetkili? CariYetkili { get; set; }
        public int MalzemeTalepId { get; set; }
        public MalzemeTalep? MalzemeTalep { get; set; }
        public bool Status { get; set; } = false;
        public double? Boyut1 { get; set; }
        public double? Boyut2 { get; set; }
        public double? Boyut3 { get; set; }
        public double? Boyut4 { get; set; }
        public int? BirimId { get; set; }
        public int? BirimSayisi { get; set; }
        public string? BirimFiyat { get; set; }
        public int? KdvId { get; set; }
        public int? ParaBirimId { get; set; }
        public int? OdemeVadeId { get; set; }
        public int? TeslimatAdresId { get; set; }
        public DateTime? TeslimatTarih { get; set; }
        public string? TeslimatNot { get; set; }
        public bool? Mevcut { get; set; }
        public decimal Tutar { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SelectedCariCariYetkililer>? SelectedCariCariYetkililer { get; set; }
        public List<SelectedMalzemeTalepler>? SelectedMalzemeTalepler { get; set; }
        public List<MalzemeTalepler>? MalzemeTalepler { get; set; } = new List<MalzemeTalepler>();
        public IReadOnlyList<MalzemeTalepViewModel>? MalzemeTalepViewModels { get; set; } = new List<MalzemeTalepViewModel>();
        public IReadOnlyList<CariViewModel>? CariViewModels { get; set; } = new List<CariViewModel>();
    }

    public class SelectedCariCariYetkililer
    {
        public int CariId { get; set; }
        public int CariYetkiliId { get; set; }
    }

    public class SelectedMalzemeTalepler
    {
        public int MalzemeTalepId { get; set; }
        public bool IsSelected { get; set; }
    }

    public class MalzemeTalepler
    {
        public int CariId { get; set; }
        public CariViewModel CariViewModel { get; set; } = null!;
        public int CariYetkiliId { get; set; }
        public CariYetkiliViewModel CariYetkiliViewModel { get; set; } = null!;
        public int MalzemeTalepId { get; set; }
        public MalzemeTalepViewModel MalzemeTalepViewModel { get; set; } = null!;
        public bool Status { get; set; }
    }
}