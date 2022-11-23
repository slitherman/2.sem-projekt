using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class BookstoreDbContext:DbContext 
    {
        protected void OnConfiguration(DbContextOptionsBuilder opt)
        {
            opt.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public virtual DbSet<Boghandler> boghandler { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Fag> Fag { get; set; }
        public virtual DbSet<Hold> Hold { get; set; }
        public virtual DbSet<Koordinator> Koordinator { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }
        public virtual DbSet<Uddannelser> Uddannelser { get; set; }
        public virtual DbSet<Underviser> Underviser { get; set; }

    }
}
