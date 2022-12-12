using _2._sem_projekt_boglistesystemet;
using _2._sem_projekt_boglistesystemet.Helpers;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using _2._sem_projekt_boglistesystemet.Services;
using Bogus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BoglisteSystemTestEnvironment
{
    public class Tests: Startup

    {

        BookstoreDbContext Context;
        BookstoreDbContext Service;

        //[SetUp]
        //public override void ConfigureServices(IServiceCollection services)
        //{
        //    services
        //        .AddEntityFrameworkInMemoryDatabase()
        //        .AddDbContext<BookstoreDbContext>((sp, options) =>
        //        {
        //            options.UseInMemoryDatabase().UseInternalServiceProvider(sp);
        //        });
        //    base.ConfigureServices(services);
        //}
        //public async Task<BookstoreDbContext> GetContextAsync()
        //{
        //    var options = new DbContextOptionsBuilder<BookstoreDbContext>()
        //     .UseInMemoryDatabase(databaseName: "BogListeSystemDb")
        //    .Options;
        //    var databaseContext= new BookstoreDbContext(options);
        //    databaseContext.Database.EnsureCreated();

        //    if (await databaseContext.Bøger.CountAsync() <0)
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {

        //            await databaseContext.AddAsync(

        //                  new Books()
        //                  {

        //                      BogId = 33,
        //                      Name = "test",
        //                      Author = "TEST",
        //                      Year = new DateTime(1999, 1, 1),
        //                      ISBN = 32232544


        //                  });
        //            var hold = new Hold()
        //            {
        //                HoldId = 111,
        //                Name = "test",

        //            };


        //        }
        //        await databaseContext.SaveChangesAsync();   
        //    }

        //    return databaseContext;
        //}


        public List<Books> BookListGenerate(int count)
        {
            var faker = new Faker<Books>()
            .RuleFor(c => c.BogId, f => f.IndexGlobal)
            .RuleFor(c => c.Author, f => f.Person.FullName)
            .RuleFor(c => c.Year, f => f.Date.Past())
            .RuleFor(c => c.Name, f => f.Lorem.Word())
            .RuleFor(c => c.ISBN, f => f.UniqueIndex);


            return faker.Generate(count);
        }
        public void Setup()
        {
          Context  = new BookstoreDbContext();
        }
        [Test]
        public void add_book_reference_test()
        {
            //var data= BookListGenerate(1);
            //var mock = new Mock<BookstoreDbContext>();
            //mock.Setup(c => c.)
        }
        //public async Task Addbookrefasynctest()
        //{
        //    var book = new Books()
        //    {
        //        BogId = 33,
        //        Name = "test",
        //        Author = "TEST",
        //        Year = new DateTime(1999, 1, 1),
        //        ISBN = 32232544
        //    };
        //    var hold = new Hold()
        //    {
        //        HoldId = 111,
        //        Name = "test",

        //    };
        //    var dbContext = await GetContextAsync();
        //    var underviserbooks= new UnderviserService(dbContext);  
        //    var result=  underviserbooks.AddBookReference(book,hold);

        //    Assert.IsTrue(true);
        //}
        [Test]
        public async Task AddBookRef_Test()
        {
            var book = new Books()
            {
                BogId = 33,
                Name = "test",
                Author = "TEST",
                Year = new DateTime(1999, 1, 1),
                ISBN = 32232544
            };
            var hold = new Hold()
            {
                HoldId = 111,
                Name = "test",
            };

            Books b = new Books(1, "green book", new DateTime(199, 1, 1), "gadaffi", 121122112);
            Hold h = new Hold("hold 4", 22);
            UnderviserService underviserService = new UnderviserService(Service);
            underviserService.Context = Context;
        await  underviserService.AddBookReference(b,h);

            //await Context.SaveChangesAsync();   
            //await underviserService.GetItemAsyncById(b.BogId);

            Assert.IsTrue(true);


          
        }
        [Test]
        public async Task AssignTeachers_Test()
        {

            Hold h = new Hold("hold 3", 22);
            Underviser u = new Underviser("p", "p", 2, "JEAN");

            koordinatorService k = new koordinatorService(Service);
            UnderviserService und = new UnderviserService(Service);
            und.Context = Context;

            var expected = Context.Undervisere
                .Include(x => x.Hold)
                   .ThenInclude(V => V.fag)
                   .FirstOrDefault(c => c.UnderviserId == u.UnderviserId);
            await und.AddItemAsync(u);
            await und.AssignTeachers(u, h);
            Underviser underviser = und.GetItemAsyncById(u.UnderviserId).Result;
            Assert.That(underviser, Is.EqualTo(expected));  

            

        }
        [Test]
        public async Task SendBookRef_Test()
        {
            Hold hold = new Hold();
            Underviser u = new Underviser();
            koordinatorService k = new koordinatorService(Service);

            await k.SendListOfReferences();
          





        }
        [Test]
        //testing bookref collection
        public async Task ReturnBookRef_Test()
        {
           
            BoghandelService b = new BoghandelService(Service);
            b.Context = Context;
            IEnumerable<Books> books = (IEnumerable<Books>)await b.GetItemsAsync();
            books = await b.ReturnReferenceList();

            foreach (var item in books)
            {

            }

            


        }
    }
}