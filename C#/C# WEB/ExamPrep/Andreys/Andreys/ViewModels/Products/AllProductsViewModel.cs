using System.Collections.Generic;

namespace Andreys.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public IEnumerable<ProductsViewModel> Products { get; set; }
    }
}
