using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Rental
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarsId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime RetumDate { get; set; }

        public virtual Car Cars { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
