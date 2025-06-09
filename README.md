# API_Documentation

## API Key:

API keys are added by creating a file named UseApiKeyAttribute and adding the following code:

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

You have to also add the following in your appsettings.json file.

```json
"ApiKeys": {
  "StandardApiKey": "PRODUCT-APINYCKEL"
}
```

## Swagger Documentation:

