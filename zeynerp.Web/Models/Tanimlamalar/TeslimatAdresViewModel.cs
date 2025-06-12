namespace zeynerp.Web.Models.Tanimlamalar
{
    public class TeslimatAdresViewModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;
        public int CariId { get; set; }
    }
}