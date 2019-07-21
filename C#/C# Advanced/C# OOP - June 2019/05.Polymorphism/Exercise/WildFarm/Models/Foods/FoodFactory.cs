namespace WildFarm.Models.Foods
{
    public class FoodFactory
    {
        public static Food Create(string[] foodArgs)
        {
            string type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            if (type == typeof(Fruit).Name)
            {
                return new Fruit(quantity);
            }
            else if (type == typeof(Meat).Name)
            {
                return new Meat(quantity);
            }
            else if (type == typeof(Seeds).Name)
            {
                return new Seeds(quantity);
            }
            else if (type == typeof(Vegetable).Name)
            {
                return new Vegetable(quantity);
            }

            return null;
        }
    }
}
