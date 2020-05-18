using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace TreasuryApp.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TreasuryApp API",
                    Version = "v1",
                    Description = "RESTful API built with ASP.NET Core 3.1",
                    Contact = new OpenApiContact
                    {
                        Name = "Damilola Eludire",
                        Url = new Uri("https://www.linkedin.com/in/eludiredamilola/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licensed to Olabisi",
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TreasuryApp API");
                options.DocumentTitle = "TreasuryApp API";
            });
            return app;
        }
    }
}
