using Microsoft.EntityFrameworkCore;
using AppDelivery.Domain.Entities;
namespace AppDelivery.Infrastructure.DataAccess;
public class AppDeliveryDbContext : DbContext
{

    public AppDeliveryDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Consumer> Consumers { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consumer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Consumer)
            .HasForeignKey(o => o.ConsumerId);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Company)
            .HasForeignKey(o => o.CompanyId);

        modelBuilder.Entity<Delivery>()
            .HasMany(d => d.Orders)
            .WithOne(o => o.Delivery)
            .HasForeignKey(o => o.DeliveryId);

        modelBuilder.Entity<Delivery>()
            .HasOne(d => d.Driver)
            .WithMany(o => o.Deliveries)
            .HasForeignKey(o => o.DeliveryPersonId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderProducts)
            .WithOne(op => op.Product)
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderProducts)
            .WithOne(op => op.Order)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

        base.OnModelCreating(modelBuilder);
    }
}
