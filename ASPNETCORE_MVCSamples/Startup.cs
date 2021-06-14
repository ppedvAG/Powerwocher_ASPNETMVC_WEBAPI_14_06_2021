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
        public Startup(IConfiguration configuration) //IConfiguration l�dt die Appsetting.json
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }//IConfiguration l�dt die Appsetting.json 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<ICar, MockCar>();
            services.AddSingleton<ICar, Car>();
            //services.AddSingleton(typeof(ICar), typeof(MockCar)); //weitere Variante (anderer Schreibstil)

            //services.AddScoped();
            //services.AddTransient()

            //MVC
            services.AddControllersWithViews(); //MVC Projekte -> ben�tigte Verzeichnisse -> Controllers + Views


            #region Weitere Framework-M�glichkeiten
            // Razor Pages Framework
            services.AddRazorPages(); // Razor Pages Framework -< ben�tigt Pages-Verzeichnis 


            //WebAPI
            //services.AddControllers(); //Ben�tigt ein Controllers Verzeichnis. 



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

            app.UseRouting(); //Controller-Methoden k�nnen aufgerufen werden 

            app.UseAuthorization();


            //Wie kommen wir auf eine Webseite unter MVC, Razor Pages, WebAPI 
            app.UseEndpoints(endpoints =>
            {
                //Routing f�r unsere MVC -> Controller -> Index (Get-Methode) 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                #region weitere Framework Varianten
                //Endpunkt f�r RazorPages
                endpoints.MapRazorPages();

                //Endpunkt f�r WebAPI 
                endpoints.MapControllers();
                #endregion
            });
        }
    }
}
