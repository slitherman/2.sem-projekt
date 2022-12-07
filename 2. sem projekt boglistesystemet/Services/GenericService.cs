using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _2._sem_projekt_boglistesystemet.Services
{
    public class GenericService<T> : IGenericInterface<T> where T : class, new()

    {
        /// <summary>
        ///id used to track changes on a given entity
        /// </summary>
        public int GenericEntityModelId { get; set; }

        bool IGenericInterface<T>.IsPersistedEntity { get { return this.GenericEntityModelId > 0; } }
        int IGenericInterface<T>.Key { get { return this.GenericEntityModelId; } }

        public BookstoreDbContext GContext { get; set; }

        /// <summary>
        /// Does this actually make sense? ig ill find out later
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// UNTESTED
       
        public async Task  AddItemAsync(T t)
        {
            //await Task.Run(() => GContext.Set<T>().Add(t));'
           await GContext.Set<T>().AddAsync(t);
           await GContext.SaveChangesAsync();


        }



        /// <summary>
        /// The purpose of the method is to abtract filtering by makeing it generic.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// UNTESTED
        public async Task<IEnumerable<T>> CheckExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await GContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();  

        }
        //UNTESTED
        public async Task DeleteItemsAsync(T t)
        {
            GContext.Set<T>().Remove(t);
            await GContext.SaveChangesAsync();

            
        }
        /// <summary>
        /// method may result in null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// UNTESTED
       

        public async Task<T> GetItemAsyncById(int id)
        {
          T item = await GContext.Set<T>().FindAsync(id);
                if (GContext == null)
            {
                return null; 

            }
            return item;
        }

        //UNTESTED
        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await GContext.Set<T>().ToListAsync();
        }
        /// <summary>
        /// not sure what i should return, set to null in the meeantime
        /// The interface is added, to access its properties in the method
        /// the GContext.Entry(existing).CurrentValues.SetValues(existing) method block is wrapped in a task.Run method to make it run asynchronously
        /// <typeparam name="T"></typeparam>
        /// <param name="updated"></param>
        /// <returns></returns>
        /// UNTESTED
        public async Task<T> UpdateItemAsync<T>(T updated) where T: class, IGenericInterface<T>
        {
            if (updated == null)
            {
                return null;
            }

            if (updated.IsPersistedEntity)
            {
                //potential error might occur
                //fix it later or something 
                T existing =  await GContext.Set<T>().FindAsync(updated.Key);
                if (existing != null)
                {
                   await Task.Run(() => GContext.Entry(existing).CurrentValues.SetValues(existing));
                }
                return existing;
            }
            return null;
            
          
   
        }
    }
}

