namespace Events.Services
{
    using Microsoft.Azure.Cosmos;

    public interface ICosmosContainerFactory
    {
        Container GetCosmosContainer(string containerName);
    }
}