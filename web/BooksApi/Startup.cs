using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BooksApi.Models;
using Microsoft.Extensions.Options;
using BooksApi.Services;

namespace BooksApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            NOTE: mapping appsettings's BookstoreDatabaseSettings section 
            to the BookstoreDatabaseSettings object
            The configuration instance to which the appsettings.json 
            file's BookstoreDatabaseSettings section binds is registered 
            in the Dependency Injection (DI) container. For example, 
            a BookstoreDatabaseSettings object's ConnectionString property 
            is populated with the BookstoreDatabaseSettings:ConnectionString 
            property in appsettings.json.
            */
            services.Configure<BookstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            /*
            NOTE: The IBookstoreDatabaseSettings interface is registered 
            in DI with a singleton service lifetime. When injected, 
            the interface instance resolves to a BookstoreDatabaseSettings object.
            */
            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);


            // NOTE: add BookService to DI, so it can be retrived by others
            services.AddSingleton<BookService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
