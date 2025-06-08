using Presentation.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.ExampleModels;

public class ProductList_Example : IExamplesProvider<IEnumerable<Product>>
{
    public IEnumerable<Product> GetExamples()
    {
        return new[]
        {
            new Product { ProductId = Guid.NewGuid(), Name = "Example One", Description = "First example in list." },
            new Product { ProductId = Guid.NewGuid(), Name = "Example Two", Description = "Second example in list." }
        };
    }
}