using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;

namespace _2._sem_projekt_boglistesystemet.Services
{
    public class UnderviserService:GenericService<Underviser>,IUnderviser
    {
        public BookstoreDbContext Context { get; set; }
        public UnderviserService(BookstoreDbContext service) :base(service)
        {
            Context = service;
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        /// UNTESTED
        public async Task AddBookReference(Books b, Hold h)
        {

            //var v = await Context.Hold.FindAsync(h.HoldId);
            var d = await Context.Hold
                .Include(x => x.Bøger)
                .FirstOrDefaultAsync(x => x.HoldId == h.HoldId);

                
            if (d == null)
            {
                throw new ArgumentNullException(nameof(h));
            }
            await Task.Run(() => d.Bøger.Add(b));
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
        public async Task AssignTeachers(Underviser u, Hold H)

        {
            Koordinator kkk = new Koordinator();
            //idk if this actually works 
            //
            var a = await Context.Undervisere
                  //.Where(z => z.UnderviserId == u.UnderviserId)
                .Include(x => x.Hold)
                   .ThenInclude(Z => Z.fag)
                   .ThenInclude(x=> x.Koordinator)
                            .FirstOrDefaultAsync(c => c.Koordinator.KoordinatorId == kkk.KoordinatorId);


        }

    }
}
