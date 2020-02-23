using System.Collections.Generic;
using IRunes.App.ViewModels.Albums;

namespace IRunes.App.Services
{
    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<AlbumInfoViewModel> GetAll();

        DetailsViewModel GetDetails(string Id);
    }
}
