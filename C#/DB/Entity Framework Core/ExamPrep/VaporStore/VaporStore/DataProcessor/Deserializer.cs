namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDtos;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";


        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var sb = new StringBuilder();
            var validGames = new List<Game>();

            foreach (var gameDto in gamesDtos)
            {
                if (IsValid(gameDto) && gameDto.Tags.Any())
                {
                    var genre = GetGenre(context, gameDto.Genre);
                    var developer = GetDeverloper(context, gameDto.Developer);
                    var tags = GetTags(context, gameDto.Tags);


                    var game = new Game
                    {
                        Name = gameDto.Name,
                        Price = gameDto.Price,
                        ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, @"yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Developer = developer,
                        Genre = genre,
                        GameTags = tags.Select(t => new GameTag
                        {
                            TagId = t.Id
                        })
                        .ToArray()
                    };

                    validGames.Add(game);

                    sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {tags.Count} tags");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static List<Tag> GetTags(VaporStoreDbContext context, string[] tagsStrings)
        {
            List<Tag> addedTags = new List<Tag>();
            var existingTags = context.Tags;
            List<Tag> resultTags = new List<Tag>();

            foreach (var tagName in tagsStrings)
            {
                if (!existingTags.Any(t => t.Name == tagName))
                {
                    var tag = new Tag { Name = tagName };

                    addedTags.Add(tag);
                    resultTags.Add(tag);
                }
                else
                {
                    resultTags.Add(existingTags.Where(t => t.Name == tagName).First());
                }
            }
            context.Tags.AddRange(addedTags);
            context.SaveChanges();

            return resultTags;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string genreName)
        {
            var genre = context.Genres.Where(g => g.Name == genreName).FirstOrDefault();

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = genreName
                };

                context.Genres.AddRange(genre);
                context.SaveChanges();

            }

            return genre;
        }

        private static Developer GetDeverloper(VaporStoreDbContext context, string developerName)
        {
            var developer = context.Developers.Where(g => g.Name == developerName).FirstOrDefault();

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = developerName
                };

                context.Developers.AddRange(developer);
                context.SaveChanges();
            }


            return developer;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDtos = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);

            var sb = new StringBuilder();
            var validUsers = new List<User>();

            foreach (var userDto in usersDtos)
            {
                if (IsValid(userDto) && userDto.Cards.All(IsValid))
                {
                    var cards = new List<Card>();

                    foreach (var cardDto in userDto.Cards)
                    {
                        bool isValidCardType = Enum.TryParse(cardDto.Type, out CardType type);

                        if (!isValidCardType)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        var card = new Card
                        {
                            Number = cardDto.Number,
                            Cvc = cardDto.Cvc,
                            Type = type
                        };


                        cards.Add(card);
                    }
                    
                    var user = new User
                    {
                        FullName = userDto.FullName,
                        Username = userDto.Username,
                        Email = userDto.Email,
                        Age = userDto.Age,
                        Cards = cards
                    };

                    validUsers.Add(user);

                    sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchasesDto[]), new XmlRootAttribute("Purchases"));

            var purchasesDto = (ImportPurchasesDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var purchases = new List<Purchase>();

            StringBuilder sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                bool isValidCardType = Enum.TryParse(purchaseDto.Type, out PurchaseType purchaseType);

                var game = context.Games.Where(g => g.Name == purchaseDto.Title).FirstOrDefault();
                var card = context.Cards.Where(c => c.Number == purchaseDto.CardNumber).FirstOrDefault();

                if (!isValidCardType || game == null || card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (IsValid(purchaseDto))
                {
                    var purchase = new Purchase
                    {
                        Game = game,
                        Card = card,
                        Type = purchaseType,
                        ProductKey = purchaseDto.CardNumber,
                        Date = DateTime.ParseExact(purchaseDto.Date, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                    };

                    purchases.Add(purchase);
                    sb.AppendLine($"Imported {purchase.Game.Name} for {card.User.Username}");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}