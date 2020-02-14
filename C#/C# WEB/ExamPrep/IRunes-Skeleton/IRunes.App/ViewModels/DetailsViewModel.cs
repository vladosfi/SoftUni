using System.Collections.Generic;

namespace IRunes.App.ViewModels
{
    public class DetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<TrackViewModel> Tracks { get; set; }
    }
}
