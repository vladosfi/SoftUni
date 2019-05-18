using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class Family
    {
        private List<Person> peoples;

        public Family()
        {
            this.Peoples = new List<Person>();
        }

        public List<Person> Peoples { get => peoples; set => peoples = value; }

        public void AddMember(Person person)
        {
            this.Peoples.Add(person);
        }

        public Person GetOldestMember()
        {
            return Peoples.OrderByDescending(p => p.Age).FirstOrDefault();
        }


    }
}
