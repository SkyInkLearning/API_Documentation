using Presentation.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.ExampleModels;

public class UpdateProductRequest_Example : IExamplesProvider<UpdateProductRequest>
{
    public UpdateProductRequest GetExamples() => new()
    {
        ProductId = Guid.NewGuid(),
        Name = "name",
        Description = "description"
    };
}
