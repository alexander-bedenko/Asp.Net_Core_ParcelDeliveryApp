using System;
using System.Threading.Tasks;
using ParcelDelivery.DAL.EF;
using ParcelDelivery.DAL.Entities;

namespace ParcelDelivery.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : BaseEntity;

        ParcelDeliveryContext Context { get; }

        void Commit();

        void Rollback();
    }
}
