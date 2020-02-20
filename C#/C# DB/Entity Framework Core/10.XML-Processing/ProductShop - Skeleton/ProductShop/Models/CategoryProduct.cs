namespace ProductShop.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public override bool Equals(object obj)
        {
            var other = (CategoryProduct)obj;

            return this.CategoryId == other.CategoryId &&
                this.ProductId == other.ProductId;
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash = (hash * 7) + CategoryId.GetHashCode();
            hash = (hash * 7) + ProductId.GetHashCode();

            return hash;
        }
    }
}
