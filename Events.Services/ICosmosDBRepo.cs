namespace Events.Services
{
    using Events.Domain.Models;

    public interface ICosmosDBRepo<T> 
        where T: ItemBase
    {
        Task<IEnumerable<T>> GetItemsAsync(string queryString);
        Task<T?> GetItemByIdAsync(Guid id);
        Task AddItemAsync(T item);
        Task UpdateItemAsync(Guid id, T item);
        Task DeleteItemByIdAsync(Guid id);
    }
}