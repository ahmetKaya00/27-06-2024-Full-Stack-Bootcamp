using Microsoft.EntityFrameworkCore;

namespace DBTechcareer.Data{

    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<Bootcamp> Bootcamps => Set<Bootcamp>();
        public DbSet<BootcampKayit> KursKayitlari => Set<BootcampKayit>();
    }
}