using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Carimage
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual Car Car { get; set; } = null!;
    }
}
