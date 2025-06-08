using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class UpdateProductRequest
{
    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
}