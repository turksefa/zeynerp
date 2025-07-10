namespace zeynerp.Core.Entities.Tanimlamalar
{
    public class ParaBirim
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Birim { get; set; } = string.Empty;
        public Status Status { get; set; }
    }
}