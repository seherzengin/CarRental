using System;
using System.Collections.Generic;

namespace CarRental.Repository.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string BrandsName { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
