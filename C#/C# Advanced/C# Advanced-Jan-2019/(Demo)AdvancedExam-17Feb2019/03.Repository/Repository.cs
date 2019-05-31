using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private int ID = -1;
        private Dictionary<int, Person> data;

        public Repository()
        {
            data = new Dictionary<int, Person>();
            ID = -1;
        }

        public void Add(Person person)
        {
            this.ID++;
            data.Add(ID, person);
        }

        public Person Get(int id)
        {
            return data[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (data.ContainsKey(id))
            {
                data[id] = newPerson;
                return true;
            }

            return false;
        }


        public bool Delete(int id)
        {
            if (data.ContainsKey(id))
            {
                data.Remove(id);
                return true;
            }

            return false;
        }

        public int Count => this.data.Count;
    }
}
