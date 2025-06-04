using Microsoft.AspNetCore.Mvc.Rendering;

namespace zeynerp.Web.Models.Tanimlamalar
{
    public class CariViewModel
    {
        public string Adi { get; set; } = string.Empty;
        public string KisaAdi { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string EPosta { get; set; } = string.Empty;
        public string VergiDairesi { get; set; } = string.Empty;
        public string VergiNumarasi { get; set; } = string.Empty;
        public string FaturaAdresi { get; set; } = string.Empty;
        public IReadOnlyList<CariTurViewModel> CariTurViewModels { get; set; } = null!;
        public IReadOnlyList<CariYetkiliViewModel> CariYetkiliViewModels { get; set; } = null!;
        public IReadOnlyList<TeslimatAdresViewModel> TeslimatAdresViewModels { get; set; } = null!;
    }
}