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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(l => l.Carriers)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .Property(l => l.Login)
                .HasMaxLength(20);

            modelBuilder.Entity<Carrier>()
                .HasMany(p => p.Services)
                .WithOne(c => c.Carrier)
                .HasForeignKey(c => c.CarrierId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Carrier>()
                .HasMany(p => p.Feedbacks)
                .WithOne(c => c.Carrier)
                .HasForeignKey(c => c.CarrierId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
