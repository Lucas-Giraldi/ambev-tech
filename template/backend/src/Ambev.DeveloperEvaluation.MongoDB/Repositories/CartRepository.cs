using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.MongoDB.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.MongoDB.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IMongoCollection<Cart> _carts;

        public CartRepository(IMongoClient mongoClient, IOptions<MongoSettings> mongoSettings)
        {
            var database = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);

            _carts = database.GetCollection<Cart>("Carts");
        }

        public async Task<Cart> CreateCart(Cart cart)
        {
            await _carts.InsertOneAsync(cart);

            return cart;
        }

        public async Task Delete(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("Invalid Id format.", nameof(id));
            }

            var result = await _carts.DeleteOneAsync(cart => cart.Id == objectId.ToString());

            if (result.DeletedCount == 0)
            {
                throw new KeyNotFoundException($"No cart found with id: {id}");
            }
        }

        public async Task<List<Cart>> GetAllCarts(int page, int size, string order)
        {
            var skip = (page - 1) * size;
            var sortDefinition = string.IsNullOrEmpty(order)
                ? Builders<Cart>.Sort.Ascending("Id")
                : order.Contains("desc")
                    ? Builders<Cart>.Sort.Descending(order.Split(' ')[0])
                    : Builders<Cart>.Sort.Ascending(order.Split(' ')[0]);

            return await _carts
                .Find(_ => true)
                .Sort(sortDefinition)
                .Skip(skip)
                .Limit(size)
                .ToListAsync();
        }

        public async Task<Cart> GetCartById(string Id)
        {
            try
            {

                if (!ObjectId.TryParse(Id, out var objectId))
                {
                    return null;
                }

                var filter = Builders<Cart>.Filter.Eq("_id", objectId);
                var cart = await _carts.Find(filter).FirstOrDefaultAsync();

                return cart;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var filter = Builders<Cart>.Filter.Eq(c => c.Id, cart.Id);
            var updateResult = await _carts.ReplaceOneAsync(filter, cart);

            if (updateResult.IsAcknowledged )
            {
                return cart; 
            }

            return null;
        }
    }
}
