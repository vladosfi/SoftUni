using IRunes.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.App.Services
{
    public interface ITracksService
    {
        void Create(string name, string link, decimal price, string albumId);

        TrackDetailViewModel Details(string albumId, string trackId);
    }
}
