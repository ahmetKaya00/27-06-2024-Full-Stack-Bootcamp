using System.ComponentModel.DataAnnotations;

namespace DBTechcareer.Data{

    public class BootcampKayit{

        [Key]
        public int KayitId {get;set;}
        public int OgrenciId {get;set;}
        public Ogrenci Ogrenci {get;set;} = null!;
        public int BootcampId {get;set;}
        public Bootcamp Bootcamp {get;set;} = null!;
        public DateTime KayitTarihi {get;set;}
        
    }
}