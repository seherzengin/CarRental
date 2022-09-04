using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.DTOs
{
    public class CarWithColorDto:CarDto
    {
        public ColorDto Color { get; set; }
    }
}
