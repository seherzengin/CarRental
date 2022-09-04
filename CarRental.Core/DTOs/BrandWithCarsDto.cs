using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.DTOs
{
    public class BrandWithCarsDto:BrandDto
    {
        public List<CarDto> Cars { get; set; }
    }
}
