using zeynerp.Core.Entities;
using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Web.Models.Tanimlamalar
{
    public class StokViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Oncul1 { get; set; }
        public string? Oncul2 { get; set; }
        public string? Oncul3 { get; set; }
        public string? Oncul4 { get; set; }
        public string? Ayrac1 { get; set; }
        public string? Ayrac2 { get; set; }
        public string? Ayrac3 { get; set; }
        public string? Ayrac4 { get; set; }
        public string? Boyut1 { get; set; }
        public string? Boyut2 { get; set; }
        public string? Boyut3 { get; set; }
        public string? Boyut4 { get; set; }
        public string? KGFormül { get; set; }
        public string? M2Formül { get; set; }
        public string? MMFormül { get; set; }
        public string? MFormül { get; set; }
        public bool? Fire1 { get; set; }
        public bool? Fire2 { get; set; }
        public bool? Fire3 { get; set; }
        public bool? Fire4 { get; set; }
        public int? Siralama1 { get; set; }
        public int? Siralama2 { get; set; }
        public int? Siralama3 { get; set; }
        public int? Siralama4 { get; set; }
        public bool Sertifika { get; set; }
        public bool SatinAlma { get; set; }
        public Status Status { get; set; }
        public int StokGrupId { get; set; }
        public int BirimId { get; set; }
        public int BirimFiyatHesaplama { get; set; }
        public Guid StokSorumluId { get; set; }
        public IReadOnlyList<StokGrupViewModel>? StokGrups { get; set; }
        public IReadOnlyList<BirimViewModel>? Birims { get; set; }
        public IReadOnlyList<ApplicationUser>? Users { get; set; }
    }
}