using Carting.Core.Models;

namespace Carting.Core.Services
{
    public interface ICartingService
    {
        List<CartItem> GetCartItems(string cartId);
        void AddCartItem(CartItem cartItem);
        bool RemoveCartItem(string cartId, int cartItemId);
    }
}

