using System.Globalization;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }

        public List<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            Username= userName;
        }

        public double TotalPrice { 
            get {
                return CartItems.Sum(x => x.Price * x.Quantity); 
            } 
        }
    }
}
