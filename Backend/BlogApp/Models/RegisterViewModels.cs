using System.ComponentModel.DataAnnotations;
using BlogApp.Entity;

namespace BlogApp.Models{

    public class RegisterViewModel{

        [Required]
        [Display(Name = "UserName")]
        public string? UserName {get;set;}

        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email {get;set;}

        [Required]
        [StringLength(10, ErrorMessage = "{0} alanı en az {2} an çok {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password {get;set;}
        
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Palolalarınız eşleşmedi.")]
        [Display(Name = "Parola Tekrar")]
        public string? ConfirmPassword {get;set;}
    }
}