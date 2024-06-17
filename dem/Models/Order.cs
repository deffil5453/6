using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dem.Models
{
    class Order
    {
        public int Id { get; set; }
        public DateOnly DateCreation { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
