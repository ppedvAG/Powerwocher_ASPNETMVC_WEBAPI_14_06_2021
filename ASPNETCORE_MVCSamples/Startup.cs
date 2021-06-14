using DependencyInjectionSampleLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration lädt die Appsetting.json
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }//IConfiguration lädt die Appsetting.json 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<ICar, MockCar>();
            services.AddSingleton<ICar, Car>();
            //services.AddSingleton(typeof(ICar), typeof(MockCar)); //weitere Variante (anderer Schreibstil)

            //services.AddScoped();
            //services.AddTransient()

            //MVC
            services.AddControllersWithViews(); //MVC Projekte -> benötigte Verzeichnisse -> Controllers + Views


            #region Weitere Framework-Möglichkeiten
            // Razor Pages Framework
            services.AddRazorPages(); // Razor Pages Framework -< benötigt Pages-Verzeichnis 


            //WebAPI
            //services.AddControllers(); //Benötigt ein Controllers Verzeichnis. 



            //services.AddMvc(); // services.AddControllersWithViews() + services.AddRazorPages() wird aufgerufen 
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Live 
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection(); //Https-Protokoll
            app.UseStaticFiles(); //wwwRoot kann verwendet

            app.UseRouting(); //Controller-Methoden können aufgerufen werden 

            app.UseAuthorization();


            //Wie kommen wir auf eine Webseite unter MVC, Razor Pages, WebAPI 
            app.UseEndpoints(endpoints =>
            {
                //Routing für unsere MVC -> Controller -> Index (Get-Methode) 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                #region weitere Framework Varianten
                //Endpunkt für RazorPages
                endpoints.MapRazorPages();

                //Endpunkt für WebAPI 
                endpoints.MapControllers();
                #endregion
            });
        }
    }
}
