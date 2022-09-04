using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Findek
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Score { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
