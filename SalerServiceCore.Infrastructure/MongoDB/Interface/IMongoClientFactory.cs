using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SalerServiceCore.Infrastructure.MongoDB.Interface
{
    public interface IMongoClientFactory
    {
        IMongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName) where TDocument : class, new();
    }
}
