using System.ComponentModel.DataAnnotations;

namespace LabProject.Models
{
    public class UserLogin
    {

        [Required(ErrorMessage = "Email adress is required")]
        [EmailAddress(ErrorMessage = "Incorrect email address format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one digit.")]
        [MinLength(8, ErrorMessage = "Your password must contain 8 characters")]
        public string Password { get; set; }
    }
}
