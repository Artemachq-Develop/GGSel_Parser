namespace GGSel_Parser
{
    internal class GameProduct
    {
        public string? Name { get; set; } = "Null Product";
        public double Price { get; set; } = 0;
        public int SalesCount { get; set; } = 0;
        public string? SellerName { get; set; } = "Null Seller";

        public override string ToString()
        {
            return $"{Name} | {Price:F0} ₽ | Продаж: {SalesCount}";
        }
    }
}
