namespace zeynerp.Application.DTOs.SatinalmaYonetimi
{
    public class MalzemeTalepleriDto
    {
        public List<SelectedCariCariYetkililer> SelectedCariCariYetkililer { get; set; }
        public List<SelectedMalzemeTalepler> SelectedMalzemeTalepler { get; set; }
    }

    public class SelectedCariCariYetkililer
    {
        public int CariId { get; set; }
        public int CariYetkiliId { get; set; }
    }

    public class SelectedMalzemeTalepler
    {
        public int MalzemeTalepId { get; set; }
        public bool IsSelected { get; set; }
    }
}