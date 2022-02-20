namespace Events.Services
{
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Configuration;

    public class CosmosContainerFactory : ICosmosContainerFactory
    {
        private readonly IConfigurationSection configurationSection;

        public CosmosContainerFactory(IConfiguration configuration)
        {
            this.configurationSection = configuration.GetSection("CosmosDb");
        }

        public Container GetCosmosContainer(string containerName)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string account = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;
            var client = new CosmosClient(account, key);

            var database = client.CreateDatabaseIfNotExistsAsync(databaseName).Result;
            database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            var container = client.GetContainer(databaseName, containerName);

            return container;
        }
    }
}