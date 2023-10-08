using System.ComponentModel.DataAnnotations;

namespace TempleteD.Models.IdentityVM
{
    public class ResetPasswordVM
    {

        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress(ErrorMessage = "Enter real Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        [MinLength(6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(6)]
        [Compare("Password", ErrorMessage = "Not Equal Password")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
