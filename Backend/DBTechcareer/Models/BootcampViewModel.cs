using DBTechcareer.Data;

namespace DBTechcareer.Models
{

    public class BootcampViewModel
    {
        public int BootcampId { get; set; }
        public string? Baslik { get; set; }
        public int? EgitmenId {get;set;}
        public ICollection<BootcampKayit> KursKayit { get; set; } = new List<BootcampKayit>();

    }
}