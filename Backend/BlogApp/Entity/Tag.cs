using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entity{

    public class Tag{
        [Key]
        public int TagId {get;set;}
        public string? Text {get;set;}
        public List<Post> Posts {get;set;} = new List<Post>();
    }
}