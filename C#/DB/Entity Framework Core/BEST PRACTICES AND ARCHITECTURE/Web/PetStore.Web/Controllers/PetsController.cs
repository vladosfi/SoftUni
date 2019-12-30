
namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using Services;
    using Services.Models.Pet;

    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
        {
            this.pets = pets;
        }

        public IActionResult All()
        {
            var allPets = this.pets.All();

            return View(allPets);
        }
    }
}