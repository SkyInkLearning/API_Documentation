using Presentation.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.ExampleModels;

public class Product_Example : IExamplesProvider<Product>
{
    public Product GetExamples()
    {
        return new Product
        {
            ProductId = Guid.NewGuid(),
            Name = "Productname",
            Description = "Product description"
        };
    }
}
