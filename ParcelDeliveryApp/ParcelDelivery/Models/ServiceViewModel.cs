using System.ComponentModel.DataAnnotations;
using ParcelDelivery.Enums;

namespace ParcelDelivery.Models
{
    public class ServiceViewModel : BaseViewModel
    {
        public int CarrierId { get; set; }

        [Required(ErrorMessage = "Enter max weight")]
        [Display(Name = "Max weight")]
        public float MaxWeight { get; set; }

        [Required(ErrorMessage = "Enter coast of transportation")]
        [Display(Name = "Coast of transportation 1 km.")]
        public decimal Coast { get; set; }

        [Required(ErrorMessage = "Choose type of cargo")]
        public TypeOfCargo TypeOfCargo { get; set; }

        [Required(ErrorMessage = "Choose area of transportation")]
        public TransportationArea TransportationArea { get; set; }

        [Required(ErrorMessage = "Enter distance")]
        public double Distance { get; set; }
    }
}