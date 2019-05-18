using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13.FamilyTree
{
    class Result
    {
        public Person MainPerson { get; set; }

        public List<Person> Parrents { get; set; }

        public List<Person> Children { get; set; }

        public Result()
        {
            this.Parrents = new List<Person>();
            this.Children = new List<Person>();
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(MainPerson.ToString());
            result.AppendLine("Parents:");
            if (Parrents.Any())
            {
                result.AppendLine(string.Join(Environment.NewLine, Parrents));
            }
            result.AppendLine("Children:");
            if (Children.Any())
            {
                result.AppendLine(string.Join(Environment.NewLine, Children));
            }
            

            return result.ToString();
        }
    }
}
