namespace Events.Services
{
    using Events.Domain.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CosmosDBRepo<T> : ICosmosDBRepo<T>
        where T : ItemBase
    {
        private readonly Container _container;

        public CosmosDBRepo(ICosmosContainerFactory cosmosContainerFactory)
        {
            this._container = cosmosContainerFactory.GetCosmosContainer(typeof(T).Name);
        }

        public async Task AddItemAsync(T item)
        {
            await this._container.CreateItemAsync(item, new PartitionKey(item.Id.ToString()));
        }

        public async Task DeleteItemByIdAsync(Guid id)
        {
            await this._container.DeleteItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
        }

        public async Task<T?> GetItemByIdAsync(Guid id)
        {
            try
            {
                var response = await this._container.ReadItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            var results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(Guid id, T item)
        {
            await this._container.UpsertItemAsync<T>(item, new PartitionKey(id.ToString()));
        }
    }
}