# API_Documentation

## API Key:

The simplest way to add API keys are added by creating files, this one named UseApiKeyAttribute, and adding the following code:

```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = configuration["ApiKeys:StandardApiKey"];

        if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var key))
        {
            context.Result = new UnauthorizedObjectResult(new { success = false, error = "Invalid api-key or api-key is missing." });
            // return Task.CompletedTask;
            return;
        }

        if (string.IsNullOrWhiteSpace(apiKey) || !string.Equals(key, apiKey))
        {
            context.Result = new UnauthorizedObjectResult(new { success = false, error = "Invalid api-key." });
            // return Task.CompletedTask;
            return;
        };

        await next();
    }
}
```

And then adding [UseApiKey] above the controller which you want to use it on. You can create different api keys to use on different controllers. 

You have to also add the following in your appsettings.json file. (Also on azure if deploying there as well)

```json
"ApiKeys": {
  "StandardApiKey": "PRODUCT-APINYCKEL"
}
```

There are other ways of doing this as well which I will look into in the future.

## Swagger Documentation:






