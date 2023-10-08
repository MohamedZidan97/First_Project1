using System.ComponentModel.DataAnnotations;

namespace TempleteD.Models.IdentityVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress(ErrorMessage = "Enter real Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
