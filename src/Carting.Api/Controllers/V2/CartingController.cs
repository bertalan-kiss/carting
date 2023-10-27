using Carting.Api.Mappers;
using Carting.Api.Requests.V1;
using Carting.Api.Responses.V1;
using Carting.Core.Services;
using Carting.DataAccess.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Carting.Api.Controllers.V2;

[ApiController]
[Route("api/v2")]
public class CartingController : ControllerBase
{
    // TODO:
    // V2
    // API documentation

    private readonly ICartingService cartingService;

    public CartingController(ICartingService cartingService)
    {
        this.cartingService = cartingService;
    }

    [HttpGet]
    [Route("cart")]
    [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK), typeof(CartResponse))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError), typeof(string))]
    public IActionResult Get()
    {
        try
        {
            var result = cartingService.GetCartItems();

            return Ok(Mapper.Map(result));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("cart/{cartId}")]
    [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, nameof(HttpStatusCode.BadRequest))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError), typeof(string))]
    public IActionResult Post(string cartId, CartItemRequest request)
    {
        try
        {
            cartingService.AddCartItem(Mapper.Map(cartId, request));

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("cart/{cartId}")]
    [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, nameof(HttpStatusCode.NotFound), typeof(string))]    
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError), typeof(string))]
    public IActionResult Delete(string cartId, int itemId)
    {
        try
        {
            var result = cartingService.RemoveCartItem(cartId, itemId);

            if (result)
                return Ok();
            else
                return StatusCode(500, $"Failed to delete cart item with id: {itemId}, cart id: {cartId}");
        }
        catch (CartItemNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

