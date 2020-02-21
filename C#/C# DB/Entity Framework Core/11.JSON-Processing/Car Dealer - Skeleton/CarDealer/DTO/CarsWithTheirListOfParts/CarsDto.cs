
namespace CarDealer.DTO
{
    using Newtonsoft.Json;

    public class CarsDto
    {
        public string Make { get; set; }

        public string Model{ get; set; }

        public long TravelledDistance { get; set; }
    }
}
