using System.ComponentModel.DataAnnotations;

namespace Techcareer.Models{

    public class Product{

        [Display(Name="Bootcamp Id")]
        public int ProductId {get;set;}

        [Required(ErrorMessage = "Bootcamp adı zorunlu.")]
        [Display(Name="Bootcamp Adı")]
        public string? Name {get;set;} 

        [Required(ErrorMessage = "Bootcamp Açıklaması zorunlu.")]
        [Display(Name="Bootcamp Açıklaması")]
        [StringLength(125, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 50)] 
       public string Description {get;set;} = string.Empty;

        [Required(ErrorMessage = "Bootcamp Saati zorunlu.")]
        [Range(15,50)]
        [Display(Name="Bootcamp Saati")]
        public decimal? Clock {get;set;} 

        [Display(Name="Bootcamp Resmi")]
        public string? Image {get;set;} = string.Empty;
        public bool IsActive {get;set;}

        [Required(ErrorMessage = "Bootcamp Categorisi zorunlu.")]
        [Display(Name="Bootcamp Categorisi")]
        public int? CategoryId {get;set;}
        
    }
}