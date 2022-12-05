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

     
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        /// UNTESTED
        public async Task AddBookReference(Books b, Hold h)
        {

            var v = await Context.Hold.FindAsync(h.Id);
            if (v == null)
            {
                throw new ArgumentNullException(nameof(h));
            }
            await Task.Run(() => v.Bøger.Add(b));
            await Context.SaveChangesAsync();

            //var v=  await Context.Hold.FindAsync(h.Id);
            // await Task.Run(() =>  v.Bøger.Add(b));
            //await  Context.SaveChangesAsync();



            //    var c = await Context.Books
            //        .Where(x => x.ISBN == b.ISBN)
            //        .Include(v => v.Fag)
            //        .Include(x => x.Hold)
            //        .FirstOrDefaultAsync(x => x.ISBN ==b.ISBN);
            //    if (c == null)
            //    {
            //        throw new NullReferenceException(nameof(c));    
            //    }
            //    await Context.Books.AddAsync(c);
            //    await Context.SaveChangesAsync();

            //    return c;
            //}

        }
    }
}
