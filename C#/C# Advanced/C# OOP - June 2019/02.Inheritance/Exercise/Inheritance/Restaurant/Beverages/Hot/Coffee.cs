namespace Restaurant.Beverages.Hot
{
    public class Coffee : HotBeverage
    {
        private const decimal COFFEE_PRICE = 3.50m;

        private const double COFFEE_MILLILITERS = 50;

        public Coffee(string name, double caffeine) 
            : base(name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
