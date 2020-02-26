using IRunes.App.ViewModels.Albums;
using IRunes.Data;
using IRunes.Models;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.App.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0m
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            var allAlbums =  this.db.Albums.Select(x => new AlbumInfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return allAlbums;
        }

        public DetailsViewModel GetDetails(string id)
        {
            var album = this.db.Albums
                .Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Cover = x.Cover,
                    Tracks = x.Tracks.Select(t => new TrackInfoViewModel
                    {
                      Id = t.Id,
                      Name = t.Name
                    })
                })
                .FirstOrDefault();

            return album;
        }
    }
}
