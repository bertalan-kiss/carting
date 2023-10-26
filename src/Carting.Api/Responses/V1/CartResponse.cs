namespace Carting.Api.Responses.V1
{
	public class CartResponse
	{
		public int CartId { get; set; }
		public IEnumerable<CartItem> CartItems { get; set; }
	}

	public class CartItem
	{
        public int _id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public string Alt { get; set; }
    }
}

