using Carting.DataAccess.Models;

namespace Carting.DataAccess.Repositories
{
    public interface ICartingRepository
    {
        IList<CartItem> GetCartItems();
        IList<CartItem> GetCartItems(string cartId);
        void AddCartItem(CartItem cartItem);
        bool RemoveCartItem(string cartId, int cartItemId);
    }
}

