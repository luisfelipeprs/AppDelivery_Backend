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
    public DbSet<Review> Reviews { get; set; }
    public DbSet<PasswordResetToken> PasswordResetToken { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consumer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Consumer)
            .HasForeignKey(o => o.ConsumerId);

        // Configura o relacionamento entre Company e Order
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Company)
            .HasForeignKey(o => o.CompanyId);

        // Configura a conversão de enum para string para Driver
        modelBuilder.Entity<Driver>()
            .Property(e => e.TypeDriver)
            .HasConversion(
                v => v.ToString(),
                v => (TypeDriver)Enum.Parse(typeof(TypeDriver), v)
            );

        modelBuilder.Entity<Driver>()
            .HasOne(d => d.Company)
            .WithMany()
            .HasForeignKey(d => d.CompanyId);

        // Relacionamento entre Delivery e Order (um Delivery tem uma Order)
        modelBuilder.Entity<Delivery>()
            .HasOne(d => d.Order) // Um Delivery está associado a um Order
            .WithOne(o => o.Delivery)
            .HasForeignKey<Delivery>(d => d.OrderId); // Chave estrangeira em Delivery

        // Relacionamento entre Delivery e Driver (um Driver tem muitas Deliveries)
        modelBuilder.Entity<Delivery>()
            .HasOne(d => d.Driver)
            .WithMany(dr => dr.Deliveries)
            .HasForeignKey(d => d.DeliveryPersonId);

        // Configuração de endereços (Sender e Recipient) diretamente nas Orders
        // Como as endereços são apenas strings com latitude e longitude, não são necessárias entidades separadas
        // Remetente
        modelBuilder.Entity<Order>()
            .Property(o => o.SenderLatitude)
            .IsRequired(); // Latitude obrigatória

        modelBuilder.Entity<Order>()
            .Property(o => o.SenderLongitude)
            .IsRequired(); // Longitude obrigatória

        // Parada (opcional)
        modelBuilder.Entity<Order>()
            .Property(o => o.StopLatitude)
            .IsRequired(false); // Latitude da parada opcional

        modelBuilder.Entity<Order>()
            .Property(o => o.StopLongitude)
            .IsRequired(false); // Longitude da parada opcional

        // Destinatário
        modelBuilder.Entity<Order>()
            .Property(o => o.RecipientLatitude)
            .IsRequired(); // Latitude obrigatória

        modelBuilder.Entity<Order>()
            .Property(o => o.RecipientLongitude)
            .IsRequired(); // Longitude obrigatória

        modelBuilder.Entity<Order>()
            .Property(e => e.Status)
            .HasConversion(
                v => v.ToString(),
                v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v)
            );
        modelBuilder.Entity<Order>()
            .Property(e => e.PaymentMethod)
            .HasConversion(
                v => v.ToString(),
                v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v)
);

        // Configuração do enum EntityType para Review
        modelBuilder.Entity<Review>()
            .Property(e => e.EntityType)
            .HasConversion(
                v => v.ToString(),
                v => (EntityType)Enum.Parse(typeof(EntityType), v)
            );

        modelBuilder.Entity<PasswordResetToken>()
            .Property(e => e.TypeEntity)
            .HasConversion(
                v => v.ToString(),
                v => (TypeEntity)Enum.Parse(typeof(TypeEntity), v)
            );
        modelBuilder.Entity<Order>()
            .Property(e => e.Load)
            .HasConversion(
                v => v.ToString(),
                v => (Load)Enum.Parse(typeof(Load), v)
            );

        //modelBuilder.Entity<Review>()
        //        .HasOne(r => r.Consumer)  // Relação com o consumidor
        //        .WithMany()               // Um consumidor pode ter muitas avaliações
        //        .HasForeignKey(r => r.ConsumerId) // Chave estrangeira para o consumidor
        //        .OnDelete(DeleteBehavior.Cascade);

        // Para relacionar as avaliações de empresa e entregador, você pode usar
        // métodos para configurar as chaves estrangeiras virtualmente, mas não
        // pode definir uma chave estrangeira fixa aqui devido à mudança para EntityType.
        //modelBuilder.Entity<Review>()
        //    .HasOne<Company>()       // Relação com a empresa
        //    .WithMany()               // Uma empresa pode ter muitas avaliações
        //    .HasForeignKey(r => r.EntityId) // Usando EntityId para chave estrangeira
        //    .IsRequired(false)       // Isso permite que avaliações de empresa sejam opcionais
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Review>()
        //    .HasOne<Driver>()        // Relação com o entregador
        //    .WithMany()               // Um entregador pode ter muitas avaliações
        //    .HasForeignKey(r => r.EntityId) // Usando EntityId para chave estrangeira
        //    .IsRequired(false)       // Isso permite que avaliações de entregador sejam opcionais
        //    .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
