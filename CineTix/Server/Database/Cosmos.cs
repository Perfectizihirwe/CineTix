using Microsoft.Azure.Cosmos;
using System.Configuration;

namespace CineTix.Server.Database
{
    public class Cosmos
    {
        public CosmosClient cosmosDbClient;
        public IConfiguration _configuration;
        private string CosmosDBAccountUri;
        private string CosmosDBAccountPrimaryKey;
        public Cosmos(IConfiguration configuration) { 
            _configuration = configuration;
            CosmosDBAccountUri = _configuration.GetValue<string>("CosmosDBAccountUri");
            CosmosDBAccountPrimaryKey = _configuration.GetValue<string>("CosmosDBAccountPrimaryKey");
        }

        public CosmosClient ConnectDb()
        {
            cosmosDbClient = new CosmosClient(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
            return cosmosDbClient;
        }
    }
}
