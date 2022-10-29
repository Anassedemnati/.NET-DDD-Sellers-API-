using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SalerServiceCore.Domain.Model;
using SalerServiceCore.Infrastructure.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalerServiceCore.Domain.SellerAggregate.Abstractions;
using SalerServiceCore.Domain.SellerAggregate.Models;
using SalerServiceCore.Infrastructure.SellersRepository.Assemblers;
using SalerServiceCore.Infrastructure.SellersRepository.Dtos;

namespace SalerServiceCore.Infrastructure.SellersRepository
{
    public class MongoSellersRepository : MongoClientFactory,ISellerRepository
    {
        internal IMongoCollection<SellerDto> _collection { get; }
        
        private readonly string _collectionName = "Sellers"; 
        
        public MongoSellersRepository(IOptions<MongoDbConfiguration> options) : base(options)
        {
            _collection = _database.GetCollection<SellerDto>(options.Value?.Collections[_collectionName]);
        }

        public MongoSellersRepository(IOptions<MongoDbConfiguration> options,IMongoCollection<SellerDto> collection):base(options)
        {
            _collection = collection;
        }
        
        public async Task<IReadOnlyList<Seller>> GetSellerAsync()
        {
            try
            {
                var result = await _collection
                    .Find(_ => true)
                    .ToListAsync()
                    .ConfigureAwait(false);
                return result.ToSellers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
