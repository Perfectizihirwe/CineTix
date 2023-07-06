using Microsoft.Azure.Cosmos;
namespace CineTix.Server.Database
{
    public class MoviesContainer
    {
        private static readonly string CosmosDbName = "EmployeeManagementDB";
        private static readonly string CosmosDbContainerName = "Employees";

        private static Container MovieContainer()
        {

            CosmosClient cosmosDbClient = CosmosInitializer.Cosmos();
            Container containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
            return containerClient;
        }
    }
}
