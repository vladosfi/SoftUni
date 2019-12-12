namespace VaporStore.DataProcessor
{
    using System;
    using Data;
    using System.Linq;
    using Newtonsoft.Json;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context
                .Genres
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(gm => gm.Purchases.Any())
                    .Select(gm => new
                    {
                        Id = gm.Id,
                        Title = gm.Name,
                        Developer = gm.Developer.Name,
                        Tags = string.Join(", ", gm.GameTags.Select(gt => gt.Tag.Name)),
                        Players = gm.Purchases.Select(p => p.Card.User).Count()
                    })
                    .OrderByDescending(gm => gm.Players)
                    .ThenBy(gm => gm.Id)
                    .ToArray(),
                    TotalPlayers = g.Games.Sum(p => p.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();


            return JsonConvert.SerializeObject(games, Formatting.Indented);

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            throw new NotImplementedException();
        }
    }
}