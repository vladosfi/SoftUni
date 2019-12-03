namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2:f2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var sb = new StringBuilder();
            var movies = new List<Movie>();

            foreach (var movieDto in moviesDtos)
            {
                bool isValidEnum = Enum.TryParse<Genre>(movieDto.Genre, out Genre genre);
                var movieTitles = context.Movies.Select(t => t.Title).ToArray();

                bool isValidMovie = IsValid(movieDto);
                bool invalidTitle = movieTitles.Contains(movieDto.Title);

                if (!isValidMovie || !isValidEnum || invalidTitle)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = TimeSpan.Parse(movieDto.Duration),
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                movies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDtos = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString);

            var sb = new StringBuilder();
            var halls = new List<Hall>();

            foreach (var hallDto in hallsDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    Seat seat = new Seat
                    {
                        Hall = hall
                    };

                    hall.Seats.Add(seat);
                }

                halls.Add(hall);

                string projectionType = hall.Is3D == true ? "3D" : "4Dx";

                if (hall.Is3D && hall.Is4Dx)
                {
                    projectionType = "4Dx/3D";
                }
                else if (!hall.Is3D && !hall.Is4Dx)
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count()));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new XmlRootAttribute("Projections"));

            var projectionsDtos = (ImportProjectionsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Projection>();

            StringBuilder sb = new StringBuilder();

            foreach (var projectionDto in projectionsDtos)
            {

                var movie = context.Movies.Find(projectionDto.MovieId);
                var hall = context.Halls.Find(projectionDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    Hall = hall,
                    Movie = movie,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, @"yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                if (!IsValid(projection))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                projections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title,
                    projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]), new XmlRootAttribute("Customers"));
            var customersDtos = (ImportCustomersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var customers = new List<Customer>();
            StringBuilder sb = new StringBuilder();

            var validProjectionIds = context.Projections.Select(i => i.Id).ToHashSet();

            foreach (var customerDto in customersDtos)
            {
                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                bool isValidTicket = customerDto
                    .Tickets
                    .Select(t => t.ProjectionId)
                    .All(p => validProjectionIds.Contains(p));
                
                if (!IsValid(customer) || !isValidTicket)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                customer.Tickets = customerDto.Tickets
                    .Select(s => new Ticket
                    {
                        ProjectionId = s.ProjectionId,
                        Price = s.Price
                    })
                    .ToList();

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count()));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}