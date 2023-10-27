using Carting.DataAccess.Models;

namespace Carting.DataAccess.Repositories
{
    public interface ICartingRepository
    {
        List<CartItem> GetCartItems(string cartId);
        void AddCartItem(CartItem cartItem);
        bool RemoveCartItem(string cartId, int cartItemId);
    }
}

