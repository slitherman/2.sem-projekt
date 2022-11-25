using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;

namespace _2._sem_projekt_boglistesystemet.Interfaces
{
    public interface IKoordinator:IGenericInterface<Koordinator>
    {
        public Task AssignTeachers(Underviser u, Hold H);
        public Task SendListOfReferences();
    }
}
