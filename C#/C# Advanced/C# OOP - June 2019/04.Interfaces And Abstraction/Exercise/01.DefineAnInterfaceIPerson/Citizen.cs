namespace FoodShortage
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }


        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
