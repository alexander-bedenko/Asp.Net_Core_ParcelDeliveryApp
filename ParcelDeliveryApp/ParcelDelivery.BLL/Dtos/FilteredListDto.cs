namespace ParcelDelivery.BLL.Dtos
{
    public class FilteredListDto : BaseDto
    { 
        public int CarrierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Coast { get; set; }
        public double Time { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
