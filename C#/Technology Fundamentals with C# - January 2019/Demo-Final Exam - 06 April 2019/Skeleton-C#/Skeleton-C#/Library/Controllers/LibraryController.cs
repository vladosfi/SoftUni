using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            {
                var allBooks = db.Books.ToList();
                return View(allBooks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (book.Price < 1)
            {
                book.Price = 1;
            }

            var newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };

            using (var db = new LibraryDbContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelet = db.Books.FirstOrDefault(t => t.Id == id);

                if (bookToDelet == null)
                {
                    return RedirectToAction("Index");
                }

                return View(bookToDelet);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.Books.FirstOrDefault(t => t.Id == book.Id);

                if (bookToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;
                bookToEdit.Price = book.Price;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelet = db.Books.FirstOrDefault(t => t.Id == id);

                if (bookToDelet == null)
                {
                    return RedirectToAction("Index");
                }

                return View(bookToDelet);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelet = db.Books.FirstOrDefault(t => t.Id == book.Id);

                if (bookToDelet == null)
                {
                    return RedirectToAction("Index");
                }

                db.Books.Remove(bookToDelet);
                db.SaveChanges();
            }

            return RedirectToAction("Delete");
        }
    }
}