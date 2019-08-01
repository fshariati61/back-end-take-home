using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.BLL.Contracts.DataObjects
{
    public class Airline
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TwoDigitCode { get; set; }
        public string ThreeDigitCode { get; set; }
        public string Country { get; set; }
    }
}
