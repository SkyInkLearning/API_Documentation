namespace Presentation.Models;

public class Product
{
    public Guid ProductId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
