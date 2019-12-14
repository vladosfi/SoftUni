namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks.Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("F2")
                    })
                        .OrderByDescending(b => b.BookPrice)
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName)
                .ToArray();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context
                .Books
                .Where(b => b.Genre.ToString().ToLower() == "science" && b.PublishedOn < date)
                .Select(s => new ExportOldestBooksDtos
                {
                    Pages = s.Pages.ToString(),
                    Name = s.Name,
                    Date = s.PublishedOn.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)

                })
                .ToArray()
                .OrderByDescending(s => int.Parse(s.Pages))
                .ThenByDescending(s => DateTime.ParseExact(s.Date, @"MM/dd/yyyy", CultureInfo.InvariantCulture))
                .Take(10)
                .ToArray();

            //Serialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(ExportOldestBooksDtos[]), new XmlRootAttribute("Books"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), books, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}