using Microsoft.Azure.Cosmos;
using System.Configuration;

namespace CineTix.Server.DatabaseConfig
{
    public class Cosmos
    {
        public CosmosClient cosmosDbClient;
        public IConfiguration _configuration { get; set; }
        private string CosmosDBAccountUri;
        private string CosmosDBAccountPrimaryKey;
		private string databaseId = "CineTix";
		public Cosmos(IConfiguration configuration) { 
            _configuration = configuration;
            CosmosDBAccountUri = _configuration.GetSection("ConnectionStrings").GetSection("CosmosDBAccountUri").Value;
            CosmosDBAccountPrimaryKey = _configuration.GetSection("ConnectionStrings").GetSection("CosmosDBAccountPrimaryKey").Value;
        }

        public async Task<CosmosClient> ConnectDbAsync()
        {
            cosmosDbClient = new CosmosClient(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
			return cosmosDbClient;
        }
    }
}
