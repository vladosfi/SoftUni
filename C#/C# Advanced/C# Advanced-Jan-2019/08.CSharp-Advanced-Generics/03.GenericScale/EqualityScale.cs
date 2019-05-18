namespace GenericScale
{
    public class EqualityScale<T> 
    {
        private T Left;
        private T Right;

        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool AreEqual()
        {
            bool result = this.Left.Equals(this.Right);
            return result;
        }
    }
}
