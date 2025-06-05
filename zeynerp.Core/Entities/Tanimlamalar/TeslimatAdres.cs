namespace zeynerp.Core.Entities.Tanimlamalar
{
    public class TeslimatAdres
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public Cari Cari { get; set; } = null!;
        public string Baslik { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;
    }
}