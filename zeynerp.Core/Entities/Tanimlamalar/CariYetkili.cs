namespace zeynerp.Core.Entities.Tanimlamalar
{
    public class CariYetkili
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public Cari Cari { get; set; } = null!;
        public string AdiSoyadi { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public string EPosta { get; set; } = string.Empty;
    }
}