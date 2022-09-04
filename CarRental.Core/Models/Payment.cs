using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public int CreditCardsId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Total { get; set; }

        public virtual Creditcard CreditCards { get; set; } = null!;
        public virtual Customer Customers { get; set; } = null!;
    }
}
