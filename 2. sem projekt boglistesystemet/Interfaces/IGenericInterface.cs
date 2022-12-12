using System.Linq.Expressions;

namespace _2._sem_projekt_boglistesystemet.Interfaces
{
    public interface IGenericInterface<T>
    {
        Task AddItemAsync(T t);
        Task<IEnumerable<T>> GetItemsAsync();
        Task DeleteItemsAsync(T t);
        Task<T> GetItemAsyncById(int id);
        Task<IEnumerable<T>> CheckExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> UpdateItemAsync<T2>(T2 updated) where T2 : class, IGenericInterface<T>;

        bool IsPersistedEntity { get; }
        int Key { get; }

    }
}
