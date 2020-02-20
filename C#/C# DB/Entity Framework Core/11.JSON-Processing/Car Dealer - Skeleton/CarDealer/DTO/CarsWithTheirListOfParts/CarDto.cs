
namespace CarDealer.DTO
{
    using Newtonsoft.Json;  

    public class CarDto
    {
        [JsonProperty(PropertyName = "car")]
        public CarsDto Car { get; set; }

        [JsonProperty(PropertyName = "parts")]
        public PartsDto[] Parts { get; set; }
    }
}
