using IRunes.App.ViewModels.Tracks;
using IRunes.Data;
using IRunes.Models;
using System.Linq;

namespace IRunes.App.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string albumId, string name, string link, decimal price)
        {
            var track = new Track
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = price,
            };
            
            this.db.Tracks.Add(track);

            var allTrackPricesSum = this.db.Tracks
                .Where(x => x.AlbumId == albumId)
                .Sum(x => x.Price) + price;

            var album = this.db.Albums.Find(albumId);

            album.Price = allTrackPricesSum * 0.87M;

            this.db.SaveChanges();

        }

        public DetailsViewModel GetDetails(string albumId, string trackId)
        {
            var viewModel = this.db.Tracks
                .Where(x => x.Id == trackId)
                .Select(t => new DetailsViewModel
                {
                    Name = t.Name,
                    Link = t.Link,
                    Price = t.Price,
                    AlbumId = t.AlbumId
                })
                .FirstOrDefault();

            return viewModel;
        }
    }
}
