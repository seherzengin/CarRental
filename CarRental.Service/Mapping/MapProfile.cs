using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Repository.Models;

namespace CarRental.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Carimage, CarImageDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Findek, FindekDto>().ReverseMap();
            CreateMap<Creditcard, CreditcardDto>().ReverseMap();
            CreateMap<Rental, RentalDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();

            CreateMap<Car, CarWithCarImageDto > ();
            CreateMap<Carimage, CarImageWithCarsDto>();

            CreateMap<Car, CarWithBrandDto>();
            CreateMap<Brand, BrandWithCarsDto>();


            CreateMap<Car, CarWithColorDto>();
            CreateMap<Color, ColorWithCarsDto>();

            CreateMap<User, UserWithCustomerDto>();
            CreateMap<Customer, CustomerWithUserDto>();

            CreateMap<Findek, FindekWithCustomerDto>();
            CreateMap<Customer, CustomerWithFindekDto>();

            CreateMap<Creditcard, CreditcardWithUserDto>();

            CreateMap<Rental, RentalWithCustomerDto>();

            CreateMap<Payment, PaymentWithCustomerDto>();


        }
    }
}
