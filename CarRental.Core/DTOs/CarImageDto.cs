namespace CarRental.Core.DTOs
{
    public class CarImageDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; } 
        public DateTime Date { get; set; }
    }
}
