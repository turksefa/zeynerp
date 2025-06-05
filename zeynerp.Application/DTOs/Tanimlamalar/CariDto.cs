namespace zeynerp.Application.DTOs.Tanimlamalar
{
    public class CariDto
    {
        public string Adi { get; set; } = string.Empty;
        public string KisaAdi { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string EPosta { get; set; } = string.Empty;
        public string VergiDairesi { get; set; } = string.Empty;
        public string VergiNumarasi { get; set; } = string.Empty;
        public string FaturaAdresi { get; set; } = string.Empty;
        public int[] SelectedCariTurIds { get; set; } = null!;
        public IReadOnlyList<CariYetkiliDto> CariYetkiliDtos { get; set; } = null!;
        public IReadOnlyList<TeslimatAdresDto> TeslimatAdresDtos { get; set; } = null!;
    }
}