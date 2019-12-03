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
            var gamesDtos = JsonConvert.DeserializeObject<ImportGamesDto[]>(jsonString);

            var sb = new StringBuilder();
            var validGames = new List<Game>();

            foreach (var gameDto in gamesDtos)
            {

                if (!IsValid(gameDto) || gameDto.Tags.Length <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var developer = GetDeveloper(context, gameDto.Developer);
                var genre = GetGenre(context, gameDto.Genre);
                var tags = GetTags(context, gameDto.Tags);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                                CultureInfo.InvariantCulture),
                    Developer = developer
                };

                game.Developer = developer;
                game.Genre = genre;

                foreach (var tag in tags)
                {
                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
                }

                validGames.Add(game);

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static List<Tag> GetTags(VaporStoreDbContext context, string[] tagsDto)
        {
            var tags = context.Tags.ToArray();
            var tagsToCreate = new HashSet<Tag>();
            List<Tag> tagsToAdd = new List<Tag>();

            foreach (var tagDto in tagsDto)
            {
                var tag = tags.FirstOrDefault(t => t.Name == tagDto);

                if (tag == null)
                {
                    tag = new Tag
                    {
                        Name = tagDto
                    };

                    tagsToCreate.Add(tag);
                }

                tagsToAdd.Add(tag);
            }

            if (tagsToCreate.Count > 0)
            {
                context.Tags.AddRange(tagsToCreate);
                context.SaveChanges();
            }

            return tagsToAdd;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string genreDto)
        {
            var genre = context.Genres.FirstOrDefault(g => g.Name == genreDto);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = genreDto
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, string developerDto)
        {
            var developer = context.Developers.FirstOrDefault(d => d.Name == developerDto);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = developerDto
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDtos = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);

            var sb = new StringBuilder();
            var validUser = new List<User>();

            foreach (var userDto in usersDtos)
            {
                bool isValidEnum = true;
                var validCards = new List<Card>();

                foreach (var cardDto in userDto.Cards)
                {
                    if (!Enum.TryParse<CardType>(cardDto.Type, out CardType card))
                    {
                        isValidEnum = false;
                        break;
                    }

                    validCards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = card
                    });
                }

                if (!IsValid(userDto) || !userDto.Cards.All(IsValid) || isValidEnum == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Age = userDto.Age,
                    Email = userDto.Email
                };

                foreach (var card in validCards)
                {
                    user.Cards.Add(card);
                }

                validUser.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(validUser);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchasesDto[]), new XmlRootAttribute("Purchases"));

            var purchasesDtos = (ImportPurchasesDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var purchases = new List<Purchase>();
            var sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDtos)
            {
                var isValidType = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType purchaseType);

                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Tytle);

                if (!IsValid(purchaseDto) || !isValidType || card == null || game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
                    Game = game
                };

                purchases.Add(purchase);

                sb.AppendLine($"Imported {game.Name} for {card.User.Username}");
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