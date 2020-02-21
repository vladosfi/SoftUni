namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            List<Writer> writers = new List<Writer>();

            StringBuilder sb = new StringBuilder();

            foreach (var writerDto in writersDto)
            {
                var writer = Mapper.Map<Writer>(writerDto);

                bool isValid = IsValid(writer);

                if (isValid == false)
                {
                    sb.AppendLine("Invalid data");
                    continue;
                }

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            List<Producer> producers = new List<Producer>();

            StringBuilder sb = new StringBuilder();

            foreach (var producerDto in producersDto)
            {
                var producer = Mapper.Map<Producer>(producerDto);
                bool isValidProducer = IsValid(producer);

                if (isValidProducer == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var albums = producerDto.ProducerAlbums.Select(a => Mapper.Map<Album>(a)).ToList();
                bool hasInvalidAlbum = albums.Any(a => IsValid(a) == false);

                if (hasInvalidAlbum == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                producer.Albums = albums;

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count()));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count()));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new XmlRootAttribute("Songs"));

            var songsDtos = (ImportSongsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var songs = new List<Song>();

            StringBuilder sb = new StringBuilder();

            foreach (var songDto in songsDtos)
            {
                bool isValidGenre = Enum.IsDefined(typeof(Genre), songDto.Genre);
                var writer = context.Writers.Find(songDto.WriterId);
                var album = context.Albums.Find(songDto.AlbumId);

                if (isValidGenre == false || writer == null || album == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = Mapper.Map<Song>(songDto);

                bool isValid = IsValid(song);

                if (isValid)
                {
                    songs.Add(song);
                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSongPerformersDto[]), new XmlRootAttribute("Performers"));
            var performerDtos = (ImportSongPerformersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var performers = new List<Performer>();

            StringBuilder sb = new StringBuilder();

            var validSongsIds = context.Songs.Select(s => s.Id).ToHashSet();

            foreach (var performerDto in performerDtos)
            {
                var performer = Mapper.Map<Performer>(performerDto);

                bool isValid = IsValid(performer);

                bool hasValidSongs = performerDto.PerformersSongs
                    .Select(s => s.Id)
                    .All(x => validSongsIds.Contains(x));


                if (isValid == false || hasValidSongs == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                performer.PerformerSongs = performerDto.PerformersSongs
                    .Select(s => new SongPerformer
                    {
                        SongId = s.Id
                    })
                    .ToList();

                performers.Add(performer);

                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, 
                    performer.FirstName,
                    performer.PerformerSongs.Count()));
            }

            context.Performers.AddRange(performers);
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