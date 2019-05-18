using System.Collections.Generic;

namespace GenericSwapMethodInteger
{
    public class GenericSwap
    {
        public static void Swap<T>(List<T> values, int indexOne, int indexTwo)
        {
            T tmpVal = values[indexOne];
            values[indexOne] = values[indexTwo];
            values[indexTwo] = tmpVal;
        }
    }
}
