using _2._sem_projekt_boglistesystemet.Helpers;
using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace _2._sem_projekt_boglistesystemet.Services
{
    public class koordinatorService : GenericService<Koordinator>, IKoordinator
    {
        public BookstoreDbContext Context { get; set; }
        public IGenericInterface<Books> ig { get; set; }
        public koordinatorService(BookstoreDbContext service) :base(service)
        {
            Context = service;
        }
        public Task AssignTeachers(Underviser u, Hold H)
        {
            //idk if this actually works 
            var a = Context.Undervisere
               .Include(x => x.Hold)
                  .Include(x => x.Fag)
                   .FirstOrDefault(c => c.UnderviserId == u.UnderviserId);

            return Task.FromResult(a);
        }
        /// <summary>
        /// ????
        /// </summary>
        /// <returns></returns>
        public async Task SendListOfReferences()
        {
            Hold hold = new Hold();
            var u= new Underviser();
            
            ///are books references?
            IEnumerable<Books> books = await ig.GetItemsAsync();
            GenericSerialize.JsonSerializer(books);


            
        }
    }
}
