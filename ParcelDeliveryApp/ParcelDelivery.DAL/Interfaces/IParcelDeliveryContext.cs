using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ParcelDelivery.DAL.Entities;

namespace ParcelDelivery.DAL.Interfaces
{
    public interface IParcelDeliveryContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Carrier> Carriers { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<Service> Services { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Dispose();
        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<T> Set<T>() where T : class;
    }
}