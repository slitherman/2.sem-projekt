using _2._sem_projekt_boglistesystemet.Models;

namespace _2._sem_projekt_boglistesystemet.Interfaces
{
    public interface IBoghandler:IGenericInterface<Boghandler>

    {
            /// <summary>
            /// Needs to include multiple tables
            /// </summary>
            /// <returns></returns>
        public Task<IEnumerable<Books>> ReturnReferenceList();
    }
}
