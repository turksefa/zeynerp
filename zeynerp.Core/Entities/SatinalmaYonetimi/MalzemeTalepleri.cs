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
        public int MalzemeTalepId { get; set; }
        public MalzemeTalep MalzemeTalep { get; set; } = null!;
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
        public decimal Tutar { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? Mevcut { get; set; }

        // Navigation Properties
        public Birim Birim { get; set; } = null!;
        public KDV KDV { get; set; } = null!;
        public ParaBirim ParaBirim { get; set; } = null!;
        public OdemeVade OdemeVade { get; set; } = null!;
        public TeslimatAdres TeslimatAdres { get; set; } = null!;
    }
}