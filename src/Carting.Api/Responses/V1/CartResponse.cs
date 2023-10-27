namespace Carting.Api.Responses.V1
{
	public class CartResponse
	{
		public string CartId { get; set; }
		public IEnumerable<CartItem> CartItems { get; set; }
	}

	public class CartItem
	{
        public int _id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlt { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

