using _2._sem_projekt_boglistesystemet.Helpers;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using _2._sem_projekt_boglistesystemet.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BoglisteSystemTestEnvironment
{
    public class Tests

    {

        BookstoreDbContext Context;


       [SetUp]
        public void Setup()
        {
          Context  = new BookstoreDbContext();
        }

        [Test]
        public async Task AddBookRef_Test()
        {
            Books b = new Books(1, "green book", new DateTime(199, 1, 1), "gadaffi", 121122112);
            Hold h = new Hold("hold 4", 22);
            UnderviserService underviserService = new UnderviserService();
            underviserService.Context = Context;
            underviserService.AddBookReference(b, h);

          
        }
        [Test]
        public async Task AssignTeachers_Test()
        {
            Hold h = new Hold("hold 3", 22);
            Underviser u = new Underviser("jens", "andersen", 3, "JEAN");
            koordinatorService k = new koordinatorService();
            UnderviserService und = new UnderviserService();
            und.Context = Context;

            var expected = Context.Undervisere
                .Include(x => x.Hold)
                   .ThenInclude(V => V.fag)
                   .FirstOrDefault(c => c.UnderviserId == u.UnderviserId);

            await und.AssignTeachers(u, h);
            Underviser underviser = und.GetItemAsyncById(u.UnderviserId).Result;
            Assert.AreEqual(expected, underviser);  

            

        }
        [Test]
        public async Task SendBookRef_Test()
        {
            Hold hold = new Hold();
            Underviser u = new Underviser();
            koordinatorService k = new koordinatorService();

            await k.SendListOfReferences();
          





        }
        [Test]
        public async Task ReturnBookRef_Test()
        {
            IEnumerable<Books> books;
            BoghandelService b = new BoghandelService();
            books = await b.ReturnReferenceList();

            foreach (var item in books)
            {

            }

            


        }
    }
}