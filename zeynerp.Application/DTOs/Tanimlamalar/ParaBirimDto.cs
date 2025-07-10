using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Application.DTOs.Tanimlamalar
{
    public class ParaBirimDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Birim { get; set; } = string.Empty;
        public Status Status { get; set; }
    }
}