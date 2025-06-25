using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Core.Entities.SatinalmaYonetimi
{
    public class MalzemeTalepleri
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public Cari Cari { get; set; } = null!;
        public int CariYetkiliId { get; set; }
        public CariYetkili CariYetkili { get; set; } = null!;
        public bool Status { get; set; } = false;
        public virtual ICollection<MalzemeTalep> MalzemeTalepler { get; set; } = new List<MalzemeTalep>();
    }
}