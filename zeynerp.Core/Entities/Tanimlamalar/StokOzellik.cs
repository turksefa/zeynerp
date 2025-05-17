namespace zeynerp.Core.Entities.Tanimlamalar
{
    public class StokOzellik
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public double OzgulAgirlik { get; set; }
        public Status Status { get; set; }
    }
}