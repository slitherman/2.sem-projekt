using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class BookstoreDbContext:DbContext 
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> opt) : base(opt)
        {

        }
       protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BoglisteSystemDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //}
        public virtual DbSet<Boghandler> Boghandlere { get; set; }
        public virtual DbSet<Books> Bøger { get; set; }
        public virtual DbSet<Fag> Fag { get; set; }
        public virtual DbSet<Hold> Hold { get; set; }
        public virtual DbSet<Koordinator> Koordinatorer { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }
        public virtual DbSet<Uddannelser> Uddannelser { get; set; }
        public virtual DbSet<Underviser> Undervisere { get; set; }
        public BookstoreDbContext()
        {

        }

    }
}
