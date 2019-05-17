using BandRegister.Data;
using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BandRegisterDbContext())
            {
                var allBands = db.Bands.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var newBand = new Band
            {
                Name = band.Name,
                Members = band.Members,
                Honorarium = band.Honorarium,
                Genre = band.Genre
            };
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Add(newBand);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == id);
                if (bandToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return View(bandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == band.Id);
                bandToEdit.Name = band.Name;
                bandToEdit.Members = band.Members;
                bandToEdit.Honorarium = band.Honorarium;
                bandToEdit.Genre = band.Genre;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToDelete = db.Bands.FirstOrDefault(t => t.Id == id);
                if (bandToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return View(bandToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToDelet = db.Bands.FirstOrDefault(t => t.Id == band.Id);

                if (bandToDelet == null)
                {
                    return RedirectToAction("Index");
                }

                db.Bands.Remove(bandToDelet);
                db.SaveChanges();
            }

            return RedirectToAction("Delete");
        }
    }
}