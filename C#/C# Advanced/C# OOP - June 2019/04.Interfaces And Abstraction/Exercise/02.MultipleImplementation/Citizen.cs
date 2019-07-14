namespace BirthdayCelebrations
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }


        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public string Id { get => id; set => id = value; }

        public string Birthdate { get => birthdate; set => birthdate = value; }
    }
}
