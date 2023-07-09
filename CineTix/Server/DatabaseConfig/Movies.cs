using Microsoft.Azure.Cosmos;

namespace CineTix.Server.DatabaseConfig
{
    public class Movies
    {
        private string CosmosDbName = "CineTix";
        private string CosmosDbContainerName = "Movies";
        public Container containerClient;
        private readonly Cosmos cosmos;
        public CosmosClient cosmosDbClient;


		public Movies(Cosmos cosmos)
        {
            this.cosmos = cosmos;
        }

        public async Task ConnectDBAsync()
        {
            cosmosDbClient = await cosmos.ConnectDbAsync();
        }

		public Container MovieContainer()
        {
			containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
            return containerClient;
        }
	}
}
