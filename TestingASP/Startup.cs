using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TestingASP
{
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
}
