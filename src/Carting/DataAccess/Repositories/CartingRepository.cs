using Carting.DataAccess.Models;
using LiteDB;

namespace Carting.DataAccess.Repositories
{
    public class CartingRepository : ICartingRepository
    {
        private const string DatabasePath = "CartingDatabase.db";
        private const string CartItemsTableName = "cart_items";

        public List<CartItem> GetCartItems(int cartId)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>(CartItemsTableName);

            return collection.Find($"$.CartId = {cartId}").ToList();
        }

        public void AddCartItem(CartItem cartItem)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>(CartItemsTableName);
            collection.Insert(cartItem);
        }

        public void RemoveCartItem(int cartId, int cartItemId)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>(CartItemsTableName);

            var item = collection.FindOne(x => x.CartId == cartId && x._id == cartItemId);

            collection.Delete(cartItemId);
        }
    }
}

