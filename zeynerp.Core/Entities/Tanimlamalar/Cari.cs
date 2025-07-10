namespace zeynerp.Core.Entities.Tanimlamalar
{
    public class Cari
    {
        public int Id { get; set; }
        public string Adi { get; set; } = string.Empty;
        public string KisaAdi { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string EPosta { get; set; } = string.Empty;
        public string VergiDairesi { get; set; } = string.Empty;
        public string VergiNumarasi { get; set; } = string.Empty;
        public string FaturaAdresi { get; set; } = string.Empty;
        public CariStatus cariStatus { get; set; } = CariStatus.Beklemede;
        public ICollection<CariYetkili> CariYetkililer { get; set; } = null!;
        public ICollection<TeslimatAdres> TeslimatAdresler { get; set; } = null!;
        public ICollection<CariTur> CariTurler { get; set; } = null!;
    }
}