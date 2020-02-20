namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context
                .Genres
                .Where(g => genreNames.Contains(g.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Where(p => p.Purchases.Any()).Select(s => new
                    {
                        Id = s.Id,
                        Title = s.Name,
                        Developer = s.Developer.Name,
                        Tags = string.Join(", ", s.GameTags.Select(g => g.Tag.Name)),
                        Players = s.Purchases.Count
                    })
                        .OrderByDescending(p => p.Players)
                        .ThenBy(g => g.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Sum(g => g.Purchases.Count())
                })
                .OrderByDescending(p => p.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            return JsonConvert.SerializeObject(games, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var isValidPurchaseType = Enum.TryParse<PurchaseType>(storeType, out PurchaseType actualPurchaseType);

            var users = context
                .Users
                .Select(x => new ExportUserPurchasesByTypeDto
                {
                    Username = x.Username,
                    Purchases = x.Cards
                    .SelectMany(p => p.Purchases)
                    .Where(t => t.Type == actualPurchaseType)
                    .Select(p => new ExportPurchasesDto
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpent = x.Cards.SelectMany(p => p.Purchases)
                        .Where(t=>t.Type == actualPurchaseType)
                        .Sum(g => g.Game.Price)
                })
                .Where(p=>p.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserPurchasesByTypeDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}