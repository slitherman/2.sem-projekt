using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace _2._sem_projekt_boglistesystemet.Services
{
    public class UnderviserService : GenericService<Underviser>, IUnderviser
    {
        public BookstoreDbContext Context { get; set; }

        public UnderviserService (BookstoreDbContext context) :base(context)
        {
            Context = context;  
        }

        public async Task AddBookReference(int ISBN)
        {


            var c = await Context.Books
                .Where(x => x.ISBN == ISBN)
                .Include(v => v.Fag)
                .ThenInclude(v => v.Name)
                .ToListAsync();
            await Task.Run(() => Context.Books.AddAsync()
         

        }

        //public Task UpdateUnderviser(Underviser u)
        //{
        //    //var UpdatedUnderviser= Context.Underviser.SelectMany( x => x.Id, (, u)
        //    IEnumerable<Underviser> e = Context.Underviser.SelectMany(x => x.Id, v => v.Id,  ( x,v ) => new {x. v} )
                
            
                






        //}
    }
}
