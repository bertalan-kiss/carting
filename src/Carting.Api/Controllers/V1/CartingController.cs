using Carting.Api.Mappers;
using Carting.Api.Requests.V1;
using Carting.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Api.Controllers.V1;

[ApiController]
[Route("api/v1")]
public class CartingController : ControllerBase
{
    // TODO:
    // CartId to string
    // Status codes
    // V2
    // API documentation

    private readonly ICartingService cartingService;

    public CartingController(ICartingService cartingService)
    {
        this.cartingService = cartingService;
    }

    [HttpGet]
    [Route("cart/{cartId}")]
    public IActionResult Get(int cartId)
    {
        var result = cartingService.GetCartItems(cartId);

        return Ok(Mapper.Map(cartId, result));
    }

    [HttpPost]
    [Route("cart/{cartId}")]
    public IActionResult Post(int cartId, CartItemRequest request)
    {
        cartingService.AddCartItem(Mapper.Map(cartId, request));

        return Ok();
    }

    [HttpDelete]
    [Route("cart/{cartId}")]
    public IActionResult Delete(int cartId, int itemId)
    {
        cartingService.RemoveCartItem(cartId, itemId);

        return Ok();
    }
}

