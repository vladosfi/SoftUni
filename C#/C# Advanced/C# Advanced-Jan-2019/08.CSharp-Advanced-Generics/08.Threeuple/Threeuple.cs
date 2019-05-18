namespace _08.Threeuple
{
    public class Threeuple<T,K,D>
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }
        public D Item3 { get; set; }

        public Threeuple(T item1, K item2, D item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
