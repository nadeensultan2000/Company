
using Company.Entity;
using Company.Models;
using Company.Repository;
using Company.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Company
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataBase>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("Server=.;DataBase=HR;Trusted_Connection=True;Trust Server Certificate=True;")
                ));
            // builder.Services.AddTransient(typeof(IRepository<>),typeof(MainRepo<>));
             builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
