using System;
using System.Text;

namespace CollectionHierarchy
{
    public class Engine
    {
        private IAddCollection<string> addCollection;
        private IAddRemoveCollection<string> addRemoveCollection;
        private IMyList<string> myList;
        private StringBuilder result;

        public Engine()
        {
            this.addCollection = new AddCollection<string>();
            this.addRemoveCollection = new AddRemoveCollection<string>();
            this.myList = new MyList<string>();
            result = new StringBuilder();
    }

        public void Run()
        {
            string[] stringCollection = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int removeOperations = int.Parse(Console.ReadLine());

            AddToCollection(stringCollection, this.addCollection);
            AddToCollection(stringCollection, this.addRemoveCollection);
            AddToCollection(stringCollection, this.myList);

            RemoveFromCollection(removeOperations, this.addRemoveCollection);
            RemoveFromCollection(removeOperations, this.myList);
            
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private void RemoveFromCollection(int count, IAddRemoveCollection<string> collection)
        {
            for (int i = 0; i < count; i++)
            {
                result.Append(collection.Remove());
                result.Append(" ");
            }
            result.AppendLine();
        }

        private void AddToCollection(string[] input, IAddCollection<string> collection)
        {
            foreach (var element in input)
            {
                result.Append(collection.Add(element));
                result.Append(" ");
            }
            result.AppendLine();
        }
    }
}
