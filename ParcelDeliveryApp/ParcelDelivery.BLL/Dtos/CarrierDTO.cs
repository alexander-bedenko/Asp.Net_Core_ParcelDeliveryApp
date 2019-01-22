namespace ParcelDelivery.BLL.Dtos
{
    public class CarrierDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
