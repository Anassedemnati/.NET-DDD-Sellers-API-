using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SalerServiceCore.Domain.Model;
using SalerServiceCore.Infrastructure.MongoDB.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SalerServiceCore.Infrastructure.MongoDB.Repository
{
    [ExcludeFromCodeCoverage]
    public class MongoClientFactory : IMongoClientFactory
    {
        protected readonly IMongoDatabase _database;

        protected readonly MongoClient _client;

        protected readonly IOptions<MongoDbConfiguration> _options;

        public MongoClientFactory(IOptions<MongoDbConfiguration> options)
        {
            _options = options?? throw new ArgumentException(nameof(options));

            _client = new MongoClient(MongoClientSettings.FromConnectionString(_options.Value.ConnectionString));

            _database = _client.GetDatabase(_options.Value.Database);

        }


        public IMongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName) where TDocument : class, new()
        {
            return _database.GetCollection<TDocument>(collectionName);
        }

       
    }
}
