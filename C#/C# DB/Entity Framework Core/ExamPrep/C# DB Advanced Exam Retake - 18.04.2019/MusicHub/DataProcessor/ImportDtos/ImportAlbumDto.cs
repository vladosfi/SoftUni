
namespace MusicHub.DataProcessor.ImportDtos
{
    using Newtonsoft.Json;

    public class ImportAlbumDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }
    }
}
