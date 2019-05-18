namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] Array = new T[length];

            for (int i = 0; i < length; i++)
            {
                Array[i] = item;
            }

            return Array;
        }
    }
}
