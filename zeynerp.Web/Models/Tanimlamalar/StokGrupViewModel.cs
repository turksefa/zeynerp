using System.ComponentModel.DataAnnotations;
using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Web.Models.Tanimlamalar
{
    public class StokGrupViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Stok grup ad alanı gereklidir.")]
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public Status Status { get; set; }
    }
}