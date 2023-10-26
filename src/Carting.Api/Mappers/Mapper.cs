using Carting.Api.Requests.V1;
using Carting.Api.Responses.V1;

namespace Carting.Api.Mappers
{
    public static class Mapper
	{
		public static Core.Models.CartItem Map(int cartId, CartItemRequest request)
		{
            var cartItem = new Core.Models.CartItem
            {
                CartId = cartId,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity
            };

            if (request.Image != null)
            {
                cartItem.Image = new Core.Models.Image
                {
                    Url = request.Image.Url,
                    Alt = request.Image.Alt
                };
            }

            return cartItem;
        }

        public static CartResponse Map(int cartId, IEnumerable<Core.Models.CartItem> cartItems)
        {
            var items = new List<CartItem>();

            foreach (var cartItem in cartItems)
            {
                Responses.V1.Image image = null;

                if (cartItem.Image != null)
                {
                    image = new Responses.V1.Image
                    {
                        Url = cartItem.Image.Url,
                        Alt = cartItem.Image.Alt
                    };
                }

                items.Add(new CartItem
                {
                    _id = cartItem.Id,
                    Name = cartItem.Name,
                    Image = image,
                    Price = cartItem.Price,
                    Quantity = cartItem.Quantity
                }); ;
            }

            return new CartResponse
            {
                CartId = cartId,
                CartItems = items
            };
        }
	}
}

