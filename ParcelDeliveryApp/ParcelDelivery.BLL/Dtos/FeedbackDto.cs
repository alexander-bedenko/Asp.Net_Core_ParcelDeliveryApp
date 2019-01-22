using System;

namespace ParcelDelivery.BLL.Dtos
{ 
    public class FeedbackDto : BaseDto
    {
        public int CarrierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Message { get; set; }
    }
}
