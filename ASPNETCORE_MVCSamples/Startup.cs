using ASPNETCORE_MVCSamples.Data;
using ASPNETCORE_MVCSamples.Middleware;
using ASPNETCORE_MVCSamples.Models;
using DependencyInjectionSampleLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace ASPNETCORE_MVCSamples
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration geladener Zustand von Appsetting.json
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }//IConfiguration lädt die Appsetting.json 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddLiveReload(config =>
            //{
            //    //Configurationen

            //    // optional - use config instead
            //    //config.LiveReloadEnabled = true;
            //    //config.FolderToMonitor = Path.GetFullname(Path.Combine(Env.ContentRootPath,"..")) ;
            //});

            //Beispiel für LiveReload -> Westwind.LiveReload
            //services.AddControllersWithViews().AddRazorRuntimeCompilation(); //MVC Projekte -> benötigte Verzeichnisse -> Controllers + Views


            
            //MVC
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.Configure<SampleWebSettings>(Configuration);
            services.AddSingleton<ICar, MockCar>();
            services.AddAuthentication();

            services.AddDbContext<MovieDbContext>(options =>
            {
                //Configurationen
                options.UseInMemoryDatabase("MovieDB");
            });
            services.AddSession();

            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                    new CultureInfo("en"),
                    new CultureInfo("de"),
                    new CultureInfo("fr"),
                    //new CultureInfo("es"),
                    //new CultureInfo("ru"),
                    //new CultureInfo("ja"),
                    //new CultureInfo("ar"),
                    //new CultureInfo("zh"),
                    //new CultureInfo("en-GB")
                };
                options.DefaultRequestCulture = new RequestCulture("de");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });



            //services.AddSingleton<ICar, Car>();
            //services.AddSingleton(typeof(ICar), typeof(MockCar)); //weitere Variante (anderer Schreibstil)
            //services.AddScoped(); //new DbContext(conString) -> 
            //services.AddTransient()




            #region Weitere Framework-Möglichkeiten
            // Razor Pages Framework
            //services.AddRazorPages(); // Razor Pages Framework -< benötigt Pages-Verzeichnis 


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
               //app.UseLiveReload();
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
            app.UseAuthentication();
            app.UseSession();

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);



            #region Sample1
            //Use verwendet next() und verkettete somit. 
            app.Use(async (context, next) =>
            {
                //Request Part
                //await context.Response.WriteAsync("Vor Invoke from 1st app.Use()\n");
                await next();
                //Response Part
                //await context.Response.WriteAsync("Nach Invoke from 1st app.Use()\n");
            });

            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("Vor Invoke from 2nd app.Use()\n");
                await next();
                //await context.Response.WriteAsync("Nach Invoke from 2nd app.Use()\n");
            });


            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/images"
            });

            ////Terminierte Middleware
            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            //});
            #endregion


            #region Sample 2
            //Request                         Response
            //https://localhost:44362/        Hello from app.Run()
            //https://localhost:44362/m1      Hello from 1st app.Map()
            //https://localhost:44362/m1/xyz  Hello from 1st app.Map()
            //https://localhost:44362/m2      Hello from 2nd app.Map()
            //https://localhost:44362/m500    Hello from app.Run()
            app.Map("/m1", HandleMapOne);
            app.Map("/m2", appMap =>
            {
                appMap.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from 2nd app.Map()");
                });
            });
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from  app.Run()\n");
            //});
            #endregion


            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);

            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbnailGen();
            });

            //Wie kommen wir auf eine Webseite unter MVC, Razor Pages, WebAPI 
            app.UseEndpoints(endpoints =>
            {
                //Routing für unsere MVC -> Controller -> Index (Get-Methode) 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //MVC Endpunkt: https://localhost:12345/[Controllername]/[ActionMethode]/(optional->ID)

                //AbsoluteURL:  https://localhost:12345/Home/Index
                //Ohne ActionMethode Angabe->lande ich immer noch auf der Index:
                //https://localhost:12345/Home/ 

                //AbsoluteURL:  https://localhost:12345/
                //Ohne Controller Angabe -> Defaultwert -> Home
                //Ohne ActionMethode Angabe->lande ich immer noch auf der Index:
                //https://localhost:12345/Home/ 



                #region weitere Framework Varianten
                //Endpunkt für RazorPages
                endpoints.MapRazorPages();

                //Endpunkt für WebAPI 
                //endpoints.MapControllers();
                #endregion
            });
        }

        private static void HandleMapOne(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map");
            });
        }
    }
}
