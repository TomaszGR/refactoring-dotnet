using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refactoring.Web.Services;
using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.Printers;

namespace Refactoring.Web
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         services.AddControllersWithViews();
         services.AddTransient<IOrderService, OrderService>();
         services.AddTransient<IDealService, DealService>();
         services.AddTransient<IChamberOfCommerceApi, ChamberOfCommerceApi>();
         services.AddTransient<IDistrictOrderFactory, DistrictOrderFactory>();
         services.AddTransient<IAdvertPrinter, AdvertPrinter>();
         services.AddTransient<IDateTimeResolver, DateTimeResolver>();
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
         });
      }
   }
}
