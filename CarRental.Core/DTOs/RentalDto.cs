using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.DTOs
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        //public int CarsId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime RetumDate { get; set; }
    }
}
