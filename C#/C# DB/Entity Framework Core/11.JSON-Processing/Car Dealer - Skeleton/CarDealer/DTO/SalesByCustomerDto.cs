namespace CarDealer.DTO
{
    using Newtonsoft.Json;

    public class SalesByCustomerDto
    {
        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty(PropertyName = "spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
