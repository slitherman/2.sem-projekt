using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using _2._sem_projekt_boglistesystemet.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BoglisteSystemTestEnvironment
{
    public class Tests

    {
        private Books book;
        private Hold hold;

        public IUnderviser iu { get; set; }


        [SetUp]
        public void Setup()
        {
            book = new Books(434);
            hold = new Hold();
        }

        [Test]
        public void AddBookReferenceAsync_Test()
        {
            var book = new Books(434);
            var hold = new Hold();


            us.AddBookReference(book,hold).RunSynchronously();
            us.
            Assert.IsNotNull(result);
        }
           

           
            








        }
    }
}