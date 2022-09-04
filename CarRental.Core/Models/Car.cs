using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Car
    {
        public Car()
        {
            Carimages = new HashSet<Carimage>();
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string Plaka { get; set; } = null!;
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; } = null!;
        public string FindexScore { get; set; } = null!;

        public virtual Brand Brand { get; set; } = null!;
        public int BrandId { get; set; }
        public virtual Color Color { get; set; } = null!;
        public int ColorId { get; set; }
        public virtual ICollection<Carimage> Carimages { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
