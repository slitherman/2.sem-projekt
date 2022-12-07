using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;

namespace _2._sem_projekt_boglistesystemet.Services
{
    public class KoordinatorService : GenericService<Koordinator>, IKoordinator
    {
        public BookstoreDbContext Context { get; set; }
        public Task AssignTeachers(Underviser u, Hold H)
        {
            var a = Context.Underviser
                .Include(x => x.Hold)
                   .Include(x => x.Fag)
                   .FirstOrDefault(c => c.Id == u.Id);

             return Task.FromResult(a);
            
            

        }
    }

        public Task SendListOfReferences()
        {
           
        }
    }

