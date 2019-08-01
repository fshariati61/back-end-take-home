using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Flights.API
{
    public class FlightsREST: ServiceContracts.IFlightsREST
    {
        /// <summary>
        /// Returns the shortest path between orgin and the destination
        /// </summary>
        /// <param name="Origin"></param>
        /// <param name="Destination"></param>
        public Flights.BLL.Contracts.FlightsRestAPIResult GetShortestRoute(string Origin, string Destination)
        {
            return (BLL.RoutingBLL.GetShortestRoute(Origin, Destination));
        }

    }
}
