namespace FoodShortage
{
    public class Rebel : ICitizen, IRebel
    {
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food
        {
            get
            {
                return this.food;
            }
            private set
            {
                this.food = value;
            }
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
