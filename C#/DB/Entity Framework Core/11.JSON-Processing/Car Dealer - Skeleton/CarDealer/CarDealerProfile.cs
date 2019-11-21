namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTO;
    using CarDealer.Models;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //17. Export Cars With Their List Of Parts
            this.CreateMap<Car, CarDto>()
                    .ForMember(x => x.Car, y => y.MapFrom(x => x))
                    .ForMember(x => x.Parts, y => y.MapFrom(x => x.PartCars));

            this.CreateMap<PartCar, PartsDto>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Part.Name))
                    .ForMember(x => x.Price, y => y.MapFrom(x => $"{x.Part.Price:f2}"));
            //17. Export Cars With Their List Of Parts


            //18. Export Total Sales by Customer
            this.CreateMap<Customer, SalesByCustomerDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(x => x.Sales.Count))
                .ForMember(x => x.SpentMoney, y => y.MapFrom(c => c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))));

            //19. Export Sales with Applied Discount
            this.CreateMap<Sale, SalseDto>()
                .ForMember(x => x.Price, y => y.MapFrom(c => c.Car.PartCars.Sum(s => s.Part.Price)))
                .ForMember(x => x.PriceWithDiscount,
                y => y.MapFrom(c => $"{c.Car.PartCars.Sum(s => s.Part.Price) - (c.Car.PartCars.Sum(s => s.Part.Price) * (c.Discount) / 100):f2}"));
        }
    }
}
