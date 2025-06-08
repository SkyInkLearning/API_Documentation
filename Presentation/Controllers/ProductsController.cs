using Microsoft.AspNetCore.Mvc;
using Presentation.ExampleModels;
using Presentation.Extensions.Attributes;
using Presentation.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.Controllers;


[UseApiKey]
[Consumes("application/json")]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public partial class ProductsController : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Adds product.")]
    [SwaggerResponse(200, "Added product.")]
    [SwaggerResponse(400, "The request was either containing invalid or missing properties.")]
    [SwaggerResponse(400, "The event id given does not exist.")]
    [SwaggerRequestExample(typeof(AddProductRequest), typeof(AddProductRequest_Example))]
    public async Task<IActionResult> Create(AddProductRequest addProductRequest)
    {
        return Ok(addProductRequest);
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Updates product.")]
    [SwaggerResponse(200, "Updated product.")]
    [SwaggerResponse(400, "The request was either containing invalid or missing properties.")]
    [SwaggerResponse(400, "The event id given does not exist.")]
    [SwaggerRequestExample(typeof(AddProductRequest), typeof(AddProductRequest_Example))]
    public async Task<IActionResult> Create(UpdateProductRequest updateProductRequest)
    {
        return Ok(updateProductRequest);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets a product.")]
    [SwaggerResponse(200, "Returns the product with the given id.", typeof(Product))]
    [SwaggerResponseExample(200, typeof(Product_Example))]
    [SwaggerResponse(400, "The id given was null.")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = new Product { ProductId = Guid.NewGuid(), Name = "Product name", Description = "Product description" };

        return Ok(product);
    }

    [HttpGet("products")]
    [SwaggerOperation(Summary = "Gets all products.")]
    [SwaggerResponse(200, "Returns a list of all products.", typeof(IEnumerable<Product>))]
    [SwaggerResponseExample(200, typeof(ProductList_Example))]
    [SwaggerResponse(400, "No products exists.")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = new List<Product>
        {
            new Product { ProductId = Guid.NewGuid(), Name = "Product name one", Description = "Product description one" },
            new Product { ProductId = Guid.NewGuid(), Name = "Product name two", Description = "Product description two" }
        };
        return Ok(products);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletes a product.")]
    [SwaggerResponse(200, "Deleted the product with the given id.")]
    [SwaggerResponse(400, "The id given was null.")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok();
    }
}
