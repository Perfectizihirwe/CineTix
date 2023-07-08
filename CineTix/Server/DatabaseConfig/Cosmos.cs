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
		public Database database;
		private string databaseId = "CineTix";
		public Cosmos(IConfiguration configuration) { 
            _configuration = configuration;
            CosmosDBAccountUri = _configuration.GetSection("ConnectionStrings").GetSection("CosmosDBAccountUri").Value;
            CosmosDBAccountPrimaryKey = _configuration.GetSection("ConnectionStrings").GetSection("CosmosDBAccountPrimaryKey").Value;
        }

        public async Task<CosmosClient> ConnectDbAsync()
        {
            cosmosDbClient = new CosmosClient(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
			this.database = await cosmosDbClient.CreateDatabaseIfNotExistsAsync(databaseId);
			Console.WriteLine("Created Database: {0}\n", this.database.Id);
			return cosmosDbClient;
        }
    }
}
