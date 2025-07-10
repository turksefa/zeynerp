using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.DTOs.SatinalmaYonetimi
{
    public class MalzemeTalepleriDto
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public CariDto Cari { get; set; } = null!;
        public int CariYetkiliId { get; set; }
        public CariYetkiliDto CariYetkili { get; set; } = null!;
        public int MalzemeTalepId { get; set; }
        public MalzemeTalepDto MalzemeTalep { get; set; } = null!;
        public bool Status { get; set; } = false;
        public double? Boyut1 { get; set; }
        public double? Boyut2 { get; set; }
        public double? Boyut3 { get; set; }
        public double? Boyut4 { get; set; }
        public int? BirimId { get; set; }
        public int? BirimSayisi { get; set; }
        public decimal? BirimFiyat { get; set; }
        public int? KdvId { get; set; }
        public int? ParaBirimId { get; set; }
        public int? OdemeVadeId { get; set; }
        public int? TeslimatAdresId { get; set; }
        public DateTime? TeslimatTarih { get; set; }
        public string? TeslimatNot { get; set; }
        public bool? Mevcut { get; set; }
        public decimal Tutar { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}