using IRunes.App.ViewModels.Tracks;

namespace IRunes.App.Services
{
    public interface ITracksService
    {
        void Create(string albumId, string name, string link, decimal price);

        DetailsViewModel GetDetails(string albumId, string trackId);
    }
}
