using Microsoft.Azure.Cosmos;
namespace CineTix.Server.Database
{
    public static class Movies
    {
        private static string CosmosDbName = "MovieDB";
        private static string CosmosDbContainerName = "Movies";
        public static Container containerClient;
        private static readonly Cosmos cosmos;

        public Movies(Cosmos cosmos)
        {
            this.cosmos = cosmos;
        }

        public Container MovieContainer()
        {
            CosmosClient cosmosDbClient = cosmos.ConnectDb();
            containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
            return containerClient;
        }
    }
}
