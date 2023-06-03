using Catalog.Api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IConfiguration _configuration)
        {
            var client = new MongoClient(_configuration.GetValue<string>("DatabaseSetting:ConnectionString"));
            var database = client.GetDatabase(_configuration.GetValue<string>("DatabaseSetting:DatabaseName"));
            Products = database.GetCollection<Product>(_configuration.GetValue<string>("DatabaseSetting:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
    }
}
 