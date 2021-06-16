using System;
using ASPNETCORE_MVCSamples.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASPNETCORE_MVCSamples.Areas.Identity.IdentityHostingStartup))]
namespace ASPNETCORE_MVCSamples.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ASPNETCORE_MVCSamplesContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ASPNETCORE_MVCSamplesContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ASPNETCORE_MVCSamplesContext>();
            });
        }
    }
}