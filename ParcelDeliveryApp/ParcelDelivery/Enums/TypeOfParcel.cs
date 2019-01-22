using System.ComponentModel.DataAnnotations;

namespace ParcelDelivery.Enums
{
    public enum TypeOfCargo
    {
        [Display(Name = "Small")]
        Small,
        [Display(Name = "Medium")]
        Medium,
        [Display(Name = "Big")]
        Big
    } 
}
