using Basket.API.BasketRespository;
using Basket.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public CartController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }

        [HttpGet("{userName}", Name ="GetCart")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetCart(string userName) 
        {
            var cart = await _basketRepository.GetCart(userName);
            return Ok(cart ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateCart([FromBody] ShoppingCart cart)
        {
            return Ok(await _basketRepository.UpdateCart(cart));
        }

        [HttpDelete("{userName}", Name ="DeleteCart")]
        public async Task<ActionResult> DeleteCart(string userName)
        {
            await _basketRepository.DeleteCart(userName);
            return Ok();
        }
    }
}
