using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Web.Models.Tanimlamalar
{
    public class BirimViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public int Order { get; set; }
        public Status Status { get; set; }
    }
}