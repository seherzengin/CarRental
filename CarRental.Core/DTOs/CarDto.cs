using CarRental.Repository.Models;


namespace CarRental.Core.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Plaka { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; } 
        public string FindexScore { get; set; } 



    }
}
