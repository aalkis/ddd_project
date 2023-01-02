namespace Be_bitirme.Domain.Data
{
    public class BasketItem
    {
        public int BasketItemId { get; set; }
        public int BasketItemCount { get; set; }
        public Decimal BasketItemPrice { get; set; }
        public int ProductId { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }

    }
}
