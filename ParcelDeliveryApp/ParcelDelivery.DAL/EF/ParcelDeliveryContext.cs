using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParcelDelivery.DAL.Entities;
using ParcelDelivery.DAL.Interfaces;

namespace ParcelDelivery.DAL.EF
{
    public sealed class ParcelDeliveryContext : DbContext, IParcelDeliveryContext
    {
        private static readonly string ConnectionString = @"Server=.;Database=parceldelivery;Integrated Security=True;MultipleActiveResultSets=True;";

        public ParcelDeliveryContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
