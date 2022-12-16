using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;

namespace _2._sem_projekt_boglistesystemet.Services
{
    public class KoordinatorService : GenericService<Koordinator>, IKoordinator

    {
        public BookstoreDbContext Context { get; set; }
        public Task AssignTeachers(Underviser u, Hold H)
        {
            throw new NotImplementedException();
        }

        public Task SendListOfReferences()
        {
            throw new NotImplementedException();
        }
    }
}
