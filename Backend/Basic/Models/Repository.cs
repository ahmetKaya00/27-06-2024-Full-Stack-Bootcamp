namespace Basic.Models
{

    public class Repository
    {

        private static readonly List<Bootcamp> _bootcamps = new();

        static Repository()
        {
            _bootcamps = new List<Bootcamp>(){
                new Bootcamp() {Id = 1,
                               Title = "Full Stack Bootcamp",
                               Description ="Bootcamp süreci başladı.",
                               Image = "1.png",
                               Tags = new string[]{"html","web geliştirme"},
                               isActive = true,
                               isHome = true
                               },
                new Bootcamp() {Id = 2,
                               Title = "Game Bootcamp",
                               Description ="Bootcamp süreci başladı.",
                               Image = "2.png",
                               Tags = new string[]{"game","web geliştirme"},
                               isActive = true,
                               isHome = true
                               },
                new Bootcamp() {Id = 3,
                                Title = "Backend Bootcamp",
                                Description ="Bootcamp süreci başladı.",
                                Image = "3.png",
                                Tags = new string[]{"asp.net","web geliştirme"},
                                isActive = true,
                                isHome = false
                                },
            };
        }

        public static List<Bootcamp> Bootcamps
        {
            get
            {
                return _bootcamps;
            }
        }

        public static Bootcamp? GetById(int? id){
            return _bootcamps.FirstOrDefault(b=>b.Id == id);
        }
    }
}