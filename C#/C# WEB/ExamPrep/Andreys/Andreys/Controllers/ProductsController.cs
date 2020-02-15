using Andreys.Models;
using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;
using System;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductsInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            Enum.TryParse<Category>(input.Category, out Category category);
            Enum.TryParse<Gender>(input.Gender, out Gender gender);

            if (!Enum.IsDefined(typeof(Category), category) || !!Enum.IsDefined(typeof(Gender), gender))
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Description.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }



            this.productsService.Add(input.Name, input.Description, input.ImageUrl, input.Price, category, gender);

            return this.Redirect("/");
        }


        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.productsService.Details(id);

            return this.View(viewModel);
        }


        public HttpResponse Delete (int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
