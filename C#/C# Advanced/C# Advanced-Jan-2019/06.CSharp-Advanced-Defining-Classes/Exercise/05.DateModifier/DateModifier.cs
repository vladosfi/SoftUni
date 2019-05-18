using System;
using System.Linq;

namespace DefiningClasses
{
    class DateModifier
    {
        public double GetDifferenceInDays(string firstDate, string secondDate)
        {
            int[] one = firstDate.Split().Select(int.Parse).ToArray();
            int[] two = secondDate.Split().Select(int.Parse).ToArray();

            DateTime dateOne = new DateTime(one[0], one[1], one[2]);
            DateTime dateTwo = new DateTime(two[0], two[1], two[2]);

            return Math.Abs((dateOne - dateTwo).TotalDays);
        }
    }
}
