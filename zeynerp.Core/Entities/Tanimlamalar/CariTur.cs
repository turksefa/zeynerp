namespace zeynerp.Core.Entities.Tanimlamalar
{
    public class CariTur
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public Status Status { get; set; }
        public ICollection<Cari> Cariler { get; set; } = null!;
    }
}