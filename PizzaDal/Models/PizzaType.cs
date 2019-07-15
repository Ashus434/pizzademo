using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDal.Models
{
    public class PizzaType
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public class PizzaSize
    {
        public string Id { get; set; }
        public string Size { get; set; }
    }
}
