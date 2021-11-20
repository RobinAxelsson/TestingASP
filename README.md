# Just Custom middleware 6/3/2021

```csharp
  public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine(context.Request.BodyReader);
                context.Response.WriteAsync("First middleware\n");
                await next();
                context.Response.WriteAsync("First middleware\n");
            });

            app.Use(async (context, next) =>
            {
                context.Response.WriteAsync("Second middleware\n");
                await next();
                context.Response.WriteAsync("Second middleware\n");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Last middleware\n");
            });
        }
    }
```
