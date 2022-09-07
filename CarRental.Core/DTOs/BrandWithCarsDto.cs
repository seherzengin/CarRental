namespace CarRental.Core.DTOs
{
    public class BrandWithCarsDto : BrandDto
    {
        public List<CarDto> Cars { get; set; }
    }
}