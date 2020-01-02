namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Web.Models.Category;
    using System.Linq;
    using PetStore.Services.Models.Category;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var categoryServiceModel = new CreateCategoryServicesModel()
            {
                Name = model.Name,
                Description = model.Description
            };

            this.categoryService.Create(categoryServiceModel);

            return this.RedirectToAction("All", "Categories");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }


            var viewModel = new CategoryDetaisViewModel
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            if (viewModel.Description == null)
            {
                viewModel.Description = "No description";
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            var viewModel = new CategoryDetaisViewModel()
            {
                Name = category.Name,
                Description = category.Description
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(CategoryEditInputModel model)
        {
            if (this.categoryService.GetById(model.Id) == null)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var ecsm = new EditCategoryServiceModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            this.categoryService.Edit(ecsm);

            return this.RedirectToAction("Details", "Categories", new { id = ecsm.Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = this.categoryService.GetById(id);

            if (category == null)
            {
                return BadRequest();
            }

            if (category.Description == null)
            {
                category.Description = "No description.";
            }

            var cdvm = new DeleteCategoryViewModew()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            return this.View(cdvm);
        }

        [HttpPost]
        public IActionResult Delete(DeleteCategoryViewModew model)
        {
            bool success = this.categoryService.Remove(model.Id);

            if (success == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var categories = categoryService.All()

                .Select(c => new CategoryListViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArray();

            return this.View(categories);
        }


    }
}