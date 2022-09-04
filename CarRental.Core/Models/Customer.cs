using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Findeks = new HashSet<Findek>();
            Payments = new HashSet<Payment>();
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Findek> Findeks { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
