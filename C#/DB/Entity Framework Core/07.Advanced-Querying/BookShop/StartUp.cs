namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Threading;
    using BookShop.Models.Enums;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            using (var db = new BookShopContext())
            {  

                //DbInitializer.ResetDatabase(db);
                
                Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine()));
            }
        }

        //1.	Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command,true);

            var bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b=>b.Title)
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
