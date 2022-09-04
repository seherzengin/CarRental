using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Creditcard
    {
        public Creditcard()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int UsersId { get; set; }
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string CardCvc { get; set; } = null!;
        public string CardExpiration { get; set; } = null!;

        public virtual User Users { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
