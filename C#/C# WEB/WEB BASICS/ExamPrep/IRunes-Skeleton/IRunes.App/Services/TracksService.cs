using IRunes.App.Models;
using IRunes.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.App.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string link, decimal price, string albumId)
        {
            var track = new Track
            {
                Name = name,
                Link = link,
                Price = price,
                AlbumId = albumId,
            };

            this.db.Tracks.Add(track);

            var album = this.db.Albums.Find(albumId);
            var allTrackPricesSum = this.db.Tracks
                .Where(x => x.AlbumId == albumId)
                .Sum(x => x.Price) + price;

            album.Price = allTrackPricesSum * 0.87m;

            this.db.SaveChanges();
        }

        public TrackDetailViewModel Details(string albumId, string trackId)
        {
           return this.db.Tracks
                .Where(x => x.AlbumId == albumId)
                .Select(t => new TrackDetailViewModel
                {
                    AlbumId = albumId,
                    Name = t.Name,
                    Link = t.Link,
                    Price = t.Price
                }).FirstOrDefault();
        }
    }
}
