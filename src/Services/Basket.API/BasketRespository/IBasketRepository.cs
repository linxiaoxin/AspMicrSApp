using Basket.API.Entities;

namespace Basket.API.BasketRespository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetCart(string userName);
        Task<ShoppingCart> UpdateCart(ShoppingCart cart);
        Task DeleteCart(string userName);
    }
}
