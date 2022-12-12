using _2._sem_projekt_boglistesystemet.Models;

namespace _2._sem_projekt_boglistesystemet
{
    public class Startup
    {

        public virtual void ConfigureServices(IServiceCollection services)
       => services.AddDbContext<BookstoreDbContext>();
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
