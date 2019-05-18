using System.Collections.Generic;

namespace GenericSwapMethodString
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
