using Microsoft.Azure.Cosmos;
using System.Configuration;

namespace CineTix.Server.Database
{
    public class CosmosInitializer
    {
        private static IConfiguration _configuration;
        public CosmosInitializer(IConfiguration configuration) { 
            _configuration = configuration;
        }
        private static readonly string CosmosDBAccountUri = _configuration.GetValue<string>("CosmosDBAccountUri");
        private static readonly string CosmosDBAccountPrimaryKey = _configuration.GetValue<string>("CosmosDBAccountPrimaryKey");
        
        public static CosmosClient Cosmos()
        {

            CosmosClient cosmosDbClient = new CosmosClient(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
            return cosmosDbClient;
        }
    }
}
