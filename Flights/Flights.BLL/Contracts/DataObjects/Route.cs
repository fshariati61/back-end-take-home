using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.BLL.Contracts.DataObjects
{
    public class Route
    {
        public int ID { get; set; }
        public string AirlineID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
