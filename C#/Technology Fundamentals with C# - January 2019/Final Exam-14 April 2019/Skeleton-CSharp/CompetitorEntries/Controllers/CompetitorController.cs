using CompetitorEntries.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompetitorEntries.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly CompetitorEntriesDbContext context;

        public CompetitorController(CompetitorEntriesDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var allComp = db.Competitors.ToList();
                return View(allComp);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Competitor competitor)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var newComp = new Competitor
            {
                Name = competitor.Name,
                Age = competitor.Age,
                Team = competitor.Team,
                Category = competitor.Category

            };
            using (var db = new CompetitorEntriesDbContext())
            {
                db.Competitors.Add(newComp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var compToEdit = db.Competitors.FirstOrDefault(c => c.Id == id);
                if (compToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return View(compToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Competitor competitor)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new CompetitorEntriesDbContext())
            {
                var compToEdit = db.Competitors.FirstOrDefault(c => c.Id == competitor.Id);
                compToEdit.Name = competitor.Name;
                compToEdit.Age = competitor.Age;
                compToEdit.Team = competitor.Team;
                compToEdit.Category = competitor.Category;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var compToDelete = db.Competitors.FirstOrDefault(c => c.Id == id);
                if (compToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return View(compToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Competitor competitor)
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var compToDelet = db.Competitors.FirstOrDefault(c => c.Id == competitor.Id);

                if (compToDelet == null)
                {
                    return RedirectToAction("Index");
                }

                db.Competitors.Remove(compToDelet);
                db.SaveChanges();
            }

            return RedirectToAction("Delete");
        }
    }
}