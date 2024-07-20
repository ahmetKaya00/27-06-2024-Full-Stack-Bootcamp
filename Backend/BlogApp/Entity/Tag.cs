using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entity{

    public enum TagColors{
        primary,secondary,warning,danger,info,success
    }

    public class Tag{
        [Key]
        public int TagId {get;set;}
        public string? Text {get;set;}
        public string? Url {get;set;}
        public TagColors? Color {get;set;}
        public List<Post> Posts {get;set;} = new List<Post>();
    }
}