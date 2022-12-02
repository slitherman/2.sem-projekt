using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BoglisteSystemTestEnvironment
{
    public class Tests

    {

        public IUnderviser iu { get; set; }


        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddBookReference_Test()
        {
            var book = new Books(434);
            var hold = new Hold();


            iu.AddBookReference(book,hold);
            iu.GetItemAsyncById(hold.Id).Wait();
            Assert.AreEqual();   








        }
    }
}