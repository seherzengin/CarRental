namespace CarRental.Core.DTOs
{
    public class ColorWithCarsDto : ColorDto
    {
        public List<CarDto> Cars { get; set; }
    }
}
