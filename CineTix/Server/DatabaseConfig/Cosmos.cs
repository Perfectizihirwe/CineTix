using Microsoft.Azure.Cosmos;

namespace CineTix.Server.DatabaseConfig
{
    public class Cosmos
    {
        public CosmosClient cosmosDbClient;
        public IConfiguration Configuration { get; set; }
        private string CosmosDBAccountUri;
        private string CosmosDBAccountPrimaryKey;
		public Cosmos(IConfiguration configuration) { 
            this.Configuration = configuration;
            CosmosDBAccountUri = this.Configuration.GetSection("ConnectionStrings").GetSection("CosmosDBAccountUri").Value;
            CosmosDBAccountPrimaryKey = this.Configuration.GetSection("ConnectionStrings").GetSection("CosmosDBAccountPrimaryKey").Value;
        }

        public CosmosClient ConnectDbAsync()
        {
            cosmosDbClient = new CosmosClient(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
			return cosmosDbClient;
        }
    }
}
