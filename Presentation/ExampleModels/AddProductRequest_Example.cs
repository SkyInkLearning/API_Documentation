using Presentation.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.ExampleModels;

public class AddProductRequest_Example : IExamplesProvider<AddProductRequest>
{
    public AddProductRequest GetExamples() => new()
    {
        Name = "name",
        Description = "description"
    };
}
