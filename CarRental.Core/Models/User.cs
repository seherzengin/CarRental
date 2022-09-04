using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class User
    {
        public User()
        {
            Creditcards = new HashSet<Creditcard>();
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<Creditcard> Creditcards { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
