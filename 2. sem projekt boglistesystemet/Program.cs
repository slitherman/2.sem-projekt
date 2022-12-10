using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _2._sem_projekt_boglistesystemet
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var builder = WebApplication.CreateBuilder(args);

            //Initializing the variable to null to indicate to the compiler that i plan on assigning it later.
            //
            IConfiguration cfg = null;



        // Add services to the container.
        // adding the database connectionstring
            builder.Services.AddRazorPages();
            //builder.Services.AddDbContext<BookstoreDbContext>(options => options.UseSqlServer(cfg.GetConnectionString("DbConnection")));
            builder.Services.AddDbContext<BookstoreDbContext>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}