using System.ComponentModel.DataAnnotations;

namespace ParcelDelivery.Enums
{
    public enum TransportationArea
    {
        [Display(Name = "City")]
        City,
        [Display(Name = "Region")]
        Region,
        [Display(Name = "Country")]
        Country,
        [Display(Name = "International")]
        International
    }
}
