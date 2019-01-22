using System;
using System.ComponentModel.DataAnnotations;

namespace ParcelDelivery.Models
{
    public class FeedbackViewModel : BaseViewModel
    {
        public int CarrierId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Rate")]
        [Required(ErrorMessage = "Rate from 1 to 5")]
        public int Rating { get; set; }
        [Display(Name = "Feedback")]
        [Required(ErrorMessage = "Leave your feedback")]
        public string Message { get; set; }
    }
}