using System.ComponentModel.DataAnnotations;

namespace ParcelDelivery.Models
{
    public class UserViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Enter firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter lastname")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Spesials symbols are not allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter login")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Spesials symbols are not allowed.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is needed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Different passwords.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Wrong e-mail format.")]
        public string Email { get; set; }
    }
}
