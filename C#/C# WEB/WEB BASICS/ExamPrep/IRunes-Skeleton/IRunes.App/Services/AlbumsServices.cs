using IRunes.App.Models;
using IRunes.App.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.App.Services
{
    public class AlbumsServices : IAlbumsServices
    {
        private readonly ApplicationDbContext db;

        public AlbumsServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0m,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AlbumInfoViewModel> GetAllAlbums()
        {
            var albums = this.db.Albums
                .Select(x => new AlbumInfoViewModel
                {
                    Name = x.Name,
                    Id = x.Id
                })
                .ToList();

            return albums;
        }

        public DetailsViewModel GetAlbum(string albumId)
        {
            return this.db.Albums
                .Where(x => x.Id == albumId)
                .Select(x => new DetailsViewModel
                {
                    Id = albumId,
                    Name = x.Name,
                    Cover = x.Cover,
                    Price = x.Price,
                    Tracks = x.Tracks.Select(t => new TrackViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                    })
                    .ToList()
                })
                .FirstOrDefault();
        }

    }
}
