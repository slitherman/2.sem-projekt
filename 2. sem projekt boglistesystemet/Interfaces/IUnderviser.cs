using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;

namespace _2._sem_projekt_boglistesystemet.Interfaces
{
    public interface IUnderviser:IGenericInterface<Underviser>
    {
        public Task AddBookReference(int ISBN);
        //public Task UpdateUnderviser(Underviser underviser);
    }
}
