using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>(); //aici se seteaza implementarea concreta care sa se dea pentru un Igreeter
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              //IConfiguration configuration
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //    app.Run(async (context) =>
            //    {
            //        var greeting = configuration["Greeting"];
            //        await context.Response.WriteAsync(greeting);
            //    });

            //writing custom piece of middleware
            app.Use(next =>
            {
                // Urmeaza - functia middleware processing pipeline apelata o data per request
                return async context =>
                {
                    logger.LogInformation("Request incoming");
                    if (context.Request.Path.StartsWithSegments("/mym"))
                    {
                        await context.Response.WriteAsync("Hit!!");
                        logger.LogInformation("Request handled");
                    }
                    else
                    {
                        await next(context);
                        logger.LogInformation("Response outgoint");
                    }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
