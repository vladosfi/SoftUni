using System.Collections.Generic;

namespace IRunes.App.ViewModels.Albums
{
    public class DetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Cover { get; set; }

        public IEnumerable<TrackInfoViewModel> Tracks { get; set; }
    }
}
