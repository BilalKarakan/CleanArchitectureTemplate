using CleanArchitectureTemplate.Domain.Abstractions;

namespace CleanArchitectureTemplate.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string CategoryId { get; set; } = null!;
    public Category Category { get; set; } = null!;
}
