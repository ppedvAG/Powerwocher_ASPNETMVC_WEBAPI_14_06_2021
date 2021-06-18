using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Samples.Data;
using WebAPI_Samples.Formatters;
using WebAPI_Samples.Services;
using WebApiContrib.Core.Formatter.Bson;
using WebApiContrib.Core.Formatter.Csv;

namespace WebAPI_Samples
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
            //Verwenden von WebAPI 

            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.InputFormatters.Insert(0, new VCardInputFormatter());
                options.OutputFormatters.Insert(0, new VCardOutputFormatter());
            })
            //.AddXmlSerializerFormatters()
            .AddNewtonsoftJson();


            //services.AddControllers()
            //.AddCsvSerializerFormatters()
            //.AddXmlSerializerFormatters();


            // SwaggerUI -> Dokumentation für WebAPI und mehr
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI_Samples", Version = "v1" });
            });


            services.AddDbContext<MovieDbContext>(options =>
            {
                //Configurationen
                options.UseInMemoryDatabase("MovieDB");
                //options.UseSqlServer(Configuration.GetConnectionString("MovieDBConnectionString"));
            });

            services.AddScoped<IVideoStreamService, VideoStreamService>();
            services.AddTransient<IFileService, FileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI_Samples v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //2ter Charakter, dass hier eine WebAPI verwendet wird
                //MapController gehört zu der MVC Middleware. Client Request werden zur jeweiligen URI/Ressource geleitet.
                endpoints.MapControllers();
            });
        }
    }
}
