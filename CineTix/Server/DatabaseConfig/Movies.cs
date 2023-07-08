using Microsoft.Azure.Cosmos;

namespace CineTix.Server.DatabaseConfig
{
    public class Movies
    {
        private string CosmosDbName = "CineTix";
        private string CosmosDbContainerName = "Movies";
        public Container containerClient;
        private readonly Cosmos cosmos;

        public Movies(Cosmos cosmos)
        {
            this.cosmos = cosmos;
        }

        public async Task<Container> MovieContainer()
        {
            CosmosClient cosmosDbClient = await cosmos.ConnectDbAsync();
			containerClient = await cosmos.database.CreateContainerIfNotExistsAsync(CosmosDbContainerName, "/id", 400);
			Console.WriteLine("Created Container: {0}\n", this.containerClient.Id);
			containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
            return containerClient;
        }
    }
}
