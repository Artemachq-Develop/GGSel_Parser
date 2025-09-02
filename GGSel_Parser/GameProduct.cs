namespace GGSel_Parser
{
    public class GameProduct
    {
        public string Name { get; set; }
        public decimal PriceRub { get; set; }
        public int SalesCount { get; set; }
        public string SellerName { get; set; }

        public override string ToString()
        {
            return $"{Name} | {PriceRub:F0} ₽ | Продаж: {SalesCount}";
        }
    }
}
