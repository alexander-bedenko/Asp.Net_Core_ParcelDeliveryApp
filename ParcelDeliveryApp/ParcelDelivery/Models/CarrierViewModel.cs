using System.ComponentModel.DataAnnotations;

namespace ParcelDelivery.Models
{
    public class CarrierViewModel : BaseViewModel
    {
        [Display(Name = "Company name")]
        [Required(ErrorMessage = "Enter company name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter address of company")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter company phone")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter short description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}