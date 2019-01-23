using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.DAL.Entities;
using ParcelDelivery.DAL.Interfaces;

namespace ParcelDelivery.BLL.Services
{
    public class FeedBackService : CrudService<Feedback, FeedbackDto>, IFeedBackService
    {
        public FeedBackService(IUnitOfWork uow) 
            : base(uow)
        {
        }
    }
}
