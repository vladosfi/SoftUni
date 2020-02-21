namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .Where(r => r.Rating >= rating && r.Projections.Select(p => p.Tickets).Any())
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.SelectMany(r => r.Tickets).Sum(p => p.Price))
                .Take(10)
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                    Customers = x.Projections
                        .SelectMany(p => p.Tickets)
                        .Select(c => new
                        {
                            FirstName = c.Customer.FirstName,
                            LastName = c.Customer.LastName,
                            Balance = c.Customer.Balance.ToString("F2")
                        })
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToArray(),
                })
                .ToArray();

            return JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
               .Customers
               .Where(c => c.Age >= age)
               .OrderByDescending(c => c.Tickets.Sum(p => p.Price))
               .Select(c => new ExportTopCustomersDto
               {
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   SpentMoney = c.Tickets.Sum(p => p.Price).ToString("F2"),
                   SpentTime = new DateTime(c.Tickets.Sum(p => p.Projection.Movie.Duration.Ticks))
                        .ToString(@"HH\:mm\:ss", CultureInfo.InvariantCulture)
               })
               .Take(10)
               .ToArray();

            //Serialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(ExportTopCustomersDto[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}