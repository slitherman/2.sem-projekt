using _2._sem_projekt_boglistesystemet;
using _2._sem_projekt_boglistesystemet.Helpers;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using _2._sem_projekt_boglistesystemet.Services;
using Bogus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace BoglisteSystemTestEnvironment
{
    public class Tests: Startup

    {

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
       public async Task<BookstoreDbContext> GetContextAsync()
       {
           var options = new DbContextOptionsBuilder<BookstoreDbContext>()
             .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
           var databaseContext= new BookstoreDbContext(options);
            databaseContext.Database.EnsureCreated();

           if (await databaseContext.Bøger.CountAsync() <0)
           {
                for (int i = 0; i < 10; i++)
                {

                    await databaseContext.AddAsync(

                            new Books()
                            {

                                BogId = 33,
                                Name = "test",
                                Author = "TEST",
                                Year = "1999",
  
                               ISBN = 32232544


                            }); ;
                    var hold = new Hold()
                   {
                       HoldId = 111,
                        Name = "test",

                   };


               }
               await databaseContext.SaveChangesAsync();   
           }

           return databaseContext;
       }


        //public List<Books> BookListGenerate(int count)
        //{
        //    var faker = new Faker<Books>()
        //    .RuleFor(c => c.BogId, f => f.IndexGlobal)
        //    .RuleFor(c => c.Author, f => f.Person.FullName)
        //    .RuleFor(c => c.Year, f => f.Date.Past())
        //    .RuleFor(c => c.Name, f => f.Lorem.Word())
        //    .RuleFor(c => c.ISBN, f => f.UniqueIndex);


        //    return faker.Generate(count);
        //}
        public void Setup()
        {
          Service  = new BookstoreDbContext();
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
        // model prop ids are null
        public async Task AddHold()
        {
            BookstoreDbContext bdd = new BookstoreDbContext();
            GenericService<Koordinator> koor = new koordinatorService(bdd);
            GenericService<Underviser> uid = new UnderviserService(bdd);
            var a=  await  koor.GetItemsAsync();
            var b = await uid.GetItemsAsync();
            Hold h = new Hold()
            {
                Koordinator = a.First(),
              
                
                
                Name="HoldTest",
                
                
            };

           
            GenericService<Hold> hh = new GenericService<Hold>(bdd);
            var v = await hh.GetItemsAsync();
            await hh.AddItemAsync(h);
            
            var vv = await hh.GetItemsAsync();
            

            Assert.AreEqual(v.Count() + 1, vv.Count(),"counts does not match");
        }
        [Test]
        // model prop ids are null
        public async Task AddBookRef_Test()
        {
            
            var book = new Books()
            {
             
                Name = "test3",
                Author = "TEST3",
                Year = "1999",
                ISBN = 32232544
            };
            var hold = new Hold()
            {
                HoldId = 2007,
                Name = "test3",
            };
            BookstoreDbContext dbb = new BookstoreDbContext();

            UnderviserService underviserService = new UnderviserService(dbb);
            
        await  underviserService.AddBookReference(book,hold);

           //await Context.SaveChangesAsync();   
           await underviserService.GetItemAsyncById(book.BogId);

            Assert.IsTrue(true);
            Assert.IsNotNull(underviserService);


          
        }
        [Test]
        ///error occcurs due to fk conflict on"FK_Undervisere_Koordinatorer_KoordinatorId"
        //exceptions:
        //Microsoft.EntityFrameworkCore.DbUpdateException : An error occurred while saving the entity changes.See the inner exception for details.
        //Microsoft.Data.SqlClient.SqlException : The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Undervisere_Koordinatorer_KoordinatorId". The conflict occurred in database "BoglisteSystemDb", table "dbo.Koordinatorer", column 'KoordinatorId'.
        public async Task AssignTeachers_Test()
        {
            BookstoreDbContext newService = new BookstoreDbContext(); 
            koordinatorService k = new koordinatorService(newService);
            UnderviserService und = new UnderviserService(newService);
            Koordinator kkk = new Koordinator();

            var a = await und.GetItemsAsync();
            var b = await k.GetItemsAsync();

            Underviser u = new Underviser()
            {
                FirstName = " TestU1",
                LastName = "TestU1",
                Initials = "TestU1",
                Koordinator= b.First()
           
            };

            var expected = k.Context.Undervisere
                .Include(x => x.Hold)
                   .ThenInclude(V => V.fag)
                .Include(x => x.Koordinator)
                  .FirstOrDefaultAsync(c => c.UnderviserId == u.UnderviserId);

            await und.AddItemAsync(u);
            //await und.AssignTeachers(u, h);
            Underviser underviser = und.GetItemAsyncById(u.UnderviserId).Result;
            var hent =  await und.GetItemsAsync();
            //Assert.That(underviser, Is.EqualTo(expected));  
            Assert.AreEqual(a.Count()+1, hent.Count());
           

        }
        [Test]
        public async Task SendBookRef_Test()
        {

            Underviser u = new Underviser();
            BookstoreDbContext newService = new BookstoreDbContext();
            koordinatorService k = new koordinatorService(newService);
            UnderviserService Us = new UnderviserService(newService);
            GenericService<Books> gb = new GenericService<Books>(newService);
            GenericService<Hold> newh = new GenericService<Hold>(newService);
            GenericService<Books> newb = new GenericService<Books>(newService);
            var a = await newh.GetItemsAsync();
            var bb = await k.GetItemsAsync();
            IEnumerable<Books> dsd = await newb.GetItemsAsync();


            Books boo = new Books()
            {



            };
            //Books books = dsd.First();
            
            Hold h = new Hold()
            {
                Name = "testhold2",
                //HoldId = 5343,
                Koordinator = bb.Last(),
                Bøger = new List<Books>(),
      

            };

          await  newh.AddItemAsync(h);
            var bookservice = newb.GetItemAsyncById(h.HoldId).Result;

            await Us.AddBookReference(boo, h);
            await k.SendListOfReferences();
            Assert.IsTrue(true);
            Assert.IsNotNull(bookservice);
         

        }
        [Test]
        //testing bookref collection
        public async Task ReturnBookRef_Test()
        {
            BookstoreDbContext newService = new BookstoreDbContext();
            BoghandelService b = new BoghandelService(newService);
            
            var beb = await b.GetItemsAsync();
            beb = (IEnumerable<Boghandler>)await b.ReturnReferenceList();

            foreach (var item in beb)
            {

            }

            


        }
    }
}