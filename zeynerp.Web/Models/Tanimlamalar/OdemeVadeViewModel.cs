using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Web.Models.Tanimlamalar
{
    public class OdemeVadeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public int Sipariste { get; set; }
        public int FaturaTarihinden { get; set; }
        public int Kalan { get; set; }
        public Status Status { get; set; }
    }
}