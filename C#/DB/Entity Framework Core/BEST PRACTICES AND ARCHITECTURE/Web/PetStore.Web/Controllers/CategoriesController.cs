﻿namespace PetStore.Web.Controllers
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

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
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

            return this.RedirectToAction("All","Categories");
        }
    }
}