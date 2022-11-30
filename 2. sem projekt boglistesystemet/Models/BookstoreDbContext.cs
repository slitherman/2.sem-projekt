using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class BookstoreDbContext:DbContext 
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> opt) : base(opt)
        {

        }
       
        public virtual DbSet<Boghandler> Boghandlere { get; set; }
        public virtual DbSet<Books> Bøger { get; set; }
        public virtual DbSet<Fag> Fag { get; set; }
        public virtual DbSet<Hold> Hold { get; set; }
        public virtual DbSet<Koordinator> Koordinatorer { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }
        public virtual DbSet<Uddannelser> Uddannelser { get; set; }
        public virtual DbSet<Underviser> Undervisere { get; set; }

    }
}
