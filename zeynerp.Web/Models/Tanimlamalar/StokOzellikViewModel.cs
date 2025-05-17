using System.ComponentModel.DataAnnotations;
using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Web.Models.Tanimlamalar
{
    public class StokOzellikViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Stok özellik ad alanı gereklidir.")]
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public double OzgulAgirlik { get; set; }
        public Status Status { get; set; }
    }
}