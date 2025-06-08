using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class AddProductRequest
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
}
