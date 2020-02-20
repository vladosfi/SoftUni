namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBooksDto[]), new XmlRootAttribute("Books"));

            var booksDtos = (ImportBooksDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var books = new List<Book>();

            StringBuilder sb = new StringBuilder();


            List<string> validVals = new List<string>() { "1", "2", "3" };

            foreach (var bookDto in booksDtos)
            {
                bool isValidEnum = Enum.TryParse<Genre>(bookDto.Genre, out Genre genre);

                if (!isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!validVals.Contains(bookDto.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = bookDto.Name,
                    Genre = genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = DateTime.ParseExact(bookDto.PublishedOn, @"MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                bool isValid = IsValid(book);

                if (isValid)
                {
                    books.Add(book);
                    sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDtos = JsonConvert.DeserializeObject<ImportAuthorsDto[]>(jsonString);

            var sb = new StringBuilder();
            var validAuthors = new List<Author>();
            var existingEmails = context.Authors.Select(a => a.Email).ToHashSet();
            var existingBooksIds = context.Books.ToHashSet();

            foreach (var authorDto in authorsDtos)
            {
                if (!IsValid(authorDto) ||
                    validAuthors.Any(e => e.Email == authorDto.Email) ||
                    existingEmails.Contains(authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email
                };

                foreach (var bookIdDto in authorDto.Books)
                {
                    var curBook = existingBooksIds.FirstOrDefault(x => x.Id == bookIdDto.Id);

                    if (curBook != null)
                    {
                        var authorsBooks = new AuthorBook
                        {
                            BookId = curBook.Id
                        };

                        existingBooksIds.Add(curBook);
                        author.AuthorsBooks.Add(authorsBooks);
                    }
                }


                if (author.AuthorsBooks.Count > 0)
                {
                    validAuthors.Add(author);
                    sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }

            context.Authors.AddRange(validAuthors);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}