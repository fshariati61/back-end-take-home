using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Flights.BLL.Contracts
{
    [DataContract]
    public class FlightsRestAPIResult
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Path { get; set; }

        public FlightsRestAPIResult(string message, string path)
        {
            this.Message = message;
            this.Path = path;
        }

        public FlightsRestAPIResult()
        {
        }
    }
}
