
namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services;

    public class PetsController : Controller
    {
        private readonly IPetService pet;

        public PetsController(IPetService pet)
        {
            this.pet = pet;
        }

        public void All()
        {
            return View();
        }
    }
}