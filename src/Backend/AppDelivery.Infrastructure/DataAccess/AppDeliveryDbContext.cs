using Microsoft.EntityFrameworkCore;
using AppDelivery.Domain.Entities;
namespace AppDelivery.Infrastructure.DataAccess;
public class AppDeliveryDbContext : DbContext
{

    public AppDeliveryDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    //public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDeliveryDbContext).Assembly);
    }
}
