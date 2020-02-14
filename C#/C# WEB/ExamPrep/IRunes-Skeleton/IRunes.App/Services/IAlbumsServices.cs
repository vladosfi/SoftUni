using IRunes.App.ViewModels;
using System.Collections.Generic;

namespace IRunes.App.Services
{
    public interface IAlbumsServices
    {
        IEnumerable<AlbumInfoViewModel> GetAllAlbums();

        void Create(string name, string cover);
        DetailsViewModel GetAlbum(string albumId);

    }
}
