namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Text;
    using System.Collections.Generic;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            using (var db = new BookShopContext())
            {

                //DbInitializer.ResetDatabase(db);

                //Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine()));

                //Console.WriteLine(GetGoldenBooks(db));

                //Console.WriteLine(GetBooksByPrice(db));

                //Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(Console.ReadLine())));

                //Console.WriteLine(GetBooksByCategory(db, Console.ReadLine()));

                //Console.WriteLine(GetBooksReleasedBefore(db, Console.ReadLine()));

                //Console.WriteLine(GetAuthorNamesEndingIn(db, Console.ReadLine()));

                //Console.WriteLine(GetBookTitlesContaining(db, Console.ReadLine()));

                //Console.WriteLine(GetBooksByAuthor(db, Console.ReadLine()));

                //Console.WriteLine(CountBooks(db, int.Parse(Console.ReadLine())));

                Console.WriteLine(CountCopiesByAuthor(db));
            }
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByAuthor = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    BookCopiesCount = a.Books.Select(b=>b.Copies)
                })
                .OrderByDescending(b=>b.BookCopiesCount)
                .ToList();

            foreach (var author in booksByAuthor)
            {
                sb.AppendLine($"{author.FullName} - {author.BookCopiesCount}");
            }

            return sb.ToString().TrimEnd();
        }


        //10.	Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            var count = context
                .Books
                .Where(b => b.Title.Length > lengthCheck).Count();
            
            return count;
        }

        //9.	Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        //8.	Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var book in bookTitles)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        //7.	Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(b => new
                {
                    FullName = b.FirstName + " " + b.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        //6.	Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < releaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //5. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            List<string> categories = input.ToLower().Split().ToList();

            var books = context
                .Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }


        //4.	Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                 .Books
                 .Where(b => b.ReleaseDate.Value.Year != year)
                 .Select(b => new
                 {
                     b.Title,
                     b.BookId
                 })
                 .OrderBy(b => b.BookId)
                 .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //3.	Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //2.	Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //1.	Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            //AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command,true);

            var bookTitles = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();


            foreach (var book in bookTitles)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
    }
}
