using Microsoft.EntityFrameworkCore;
using TravelFactoryWeb.Data;

namespace TravelFactoryWeb
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         var connectionString = builder.Configuration.GetConnectionString("TravelFactoryConnection");

         builder.Services.AddDbContext<TravelFactoryContext>(options => options.UseSqlite(connectionString));

         // Add services to the container.
         builder.Services.AddControllersWithViews();

         var app = builder.Build();

         // Configure the HTTP request pipeline.
         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
         }
         app.UseStaticFiles();

         app.UseRouting();

         app.UseAuthorization();

         app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Application}/{action=Index}/{id?}");

         app.Run();
      }
   }
}
