namespace Events.Services
{
    using Events.Domain.Models;
    using Microsoft.Azure.Cosmos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CosmosDBRepo<T> : ICosmosDBRepo<T>
        where T : CosmosItemBase
    {
        private readonly Container _container;

        public CosmosDBRepo(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(T item)
        {
            await this._container.CreateItemAsync(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemByIdAsync(string id)
        {
            await this._container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        public async Task<T?> GetItemByIdAsync(string id)
        {
            try
            {
                var response = await this._container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetItemssAsync(string queryString)
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

        public async Task UpdateItemAsync(string id, T item)
        {
            await this._container.UpsertItemAsync<T>(item, new PartitionKey(id));
        }
    }
}