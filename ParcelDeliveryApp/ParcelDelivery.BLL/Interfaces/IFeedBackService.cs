using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.DAL.Entities;

namespace ParcelDelivery.BLL.Interfaces
{
    public interface IFeedBackService : ICrudService<Feedback, FeedbackDto>
    {
    }
}