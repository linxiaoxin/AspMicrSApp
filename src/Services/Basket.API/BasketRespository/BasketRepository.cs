using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Basket.API.BasketRespository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentException(nameof(redisCache));
        }

        public async Task DeleteCart(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetCart(string userName)
        {
            var cart = await _redisCache.GetStringAsync(userName);
            if(String.IsNullOrEmpty(cart))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(cart);
        }

        public async Task<ShoppingCart> UpdateCart(ShoppingCart cart)
        {
            await _redisCache.SetStringAsync(cart.Username, JsonConvert.SerializeObject(cart));
            
            return await GetCart(cart.Username);
        }
    }
}
