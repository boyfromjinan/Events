namespace Events.Services
{
    using Events.Domain.Models;

    public interface ICosmosDBRepo<T> 
        where T: CosmosItemBase
    {
        Task<IEnumerable<T>> GetItemssAsync(string queryString);
        Task<T?> GetItemByIdAsync(string id);
        Task AddItemAsync(T item);
        Task UpdateItemAsync(string id, T item);
        Task DeleteItemByIdAsync(string id);
    }
}