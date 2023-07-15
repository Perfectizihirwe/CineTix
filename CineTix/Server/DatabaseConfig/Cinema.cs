using Microsoft.Azure.Cosmos;

namespace CineTix.Server.DatabaseConfig
{
    public class Cinema
    {
        private string CosmosDbName = "CineTix";
        private string CosmosDbMoviesContainerName = "Movies";
        private string CosmosDbTicketsContainerName = "Tickets";
        public Container containerClient;
        private readonly Cosmos cosmos;
        public CosmosClient cosmosDbClient;


		public Cinema(Cosmos cosmos)
        {
            this.cosmos = cosmos;
        }

        public void ConnectDBAsync()
        {
            cosmosDbClient = cosmos.ConnectDbAsync();
        }

		public Container MovieContainer()
        {
			containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbMoviesContainerName);
            return containerClient;
        }

        public Container TicketContainer()
        {
            containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbTicketsContainerName);
            return containerClient;
        }
    }
}
