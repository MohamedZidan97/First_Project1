using System.ComponentModel.DataAnnotations;

namespace TempleteD.Models.IdentityVM
{
    public class ForgetPasswordEmailVM
    {
        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress(ErrorMessage = "Enter real Email")]
        public string Email { get; set; }
    }
}
