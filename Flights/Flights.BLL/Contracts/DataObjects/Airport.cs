using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.BLL.Contracts.DataObjects
{
    public class Airport
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA3 { get; set; }
        public double Latitute { get; set; }
        public double Longitude { get; set; }
    }
}
