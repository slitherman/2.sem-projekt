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
        public koordinatorService(BookstoreDbContext service) :base(service)
        {
            Context = service;
        }

        /// <summary>
        /// /could be made async, should work as is tho
        ///
        /// </summary>
        /// <param name="u"></param>
        /// <param name="H"></param>
        /// <returns></returns>
        public Task AssignTeachers(Underviser u, Hold H)
        {
            //idk if this actually works 
            var a = Context.Undervisere
               .Include(x => x.Hold)
                  .ThenInclude(c=> c.fag)
                  .ThenInclude(u=> u.Koordinator)
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
            GenericService<Books> bb = new GenericService<Books>(Context);

            ///are books references?
            ///doesnt work
            IEnumerable<Books> books = await bb.GetItemsAsync();
            GenericSerialize.JsonSerializer(books);


            
        }
    }
}
