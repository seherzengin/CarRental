using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public int CreditCardsId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Total { get; set; }
    }
}
