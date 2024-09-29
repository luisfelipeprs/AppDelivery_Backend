using AppDelivery.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Foreign key for Company (N:1 relationship)
    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    // Relationship with orders (1:N)
    public List<OrderProduct>? OrderProducts { get; set; }
}
