namespace zeynerp.Application.DTOs.Tanimlamalar
{
    public class CariDto
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
        public List<int> SelectedCariTurIds { get; set; } = null!;
        public ICollection<CariTurDto> CariTurDtos { get; set; } = null!;
        public ICollection<CariYetkiliDto> CariYetkiliDtos { get; set; } = null!;
        public ICollection<TeslimatAdresDto> TeslimatAdresDtos { get; set; } = null!;
    }
}