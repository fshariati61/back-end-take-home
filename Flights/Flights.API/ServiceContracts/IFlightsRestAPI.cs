using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using Flights.BLL.Contracts;

namespace Flights.API.ServiceContracts
{
    [ServiceContract(Namespace = "http://FlightsRESTAPI")]
    public interface IFlightsREST
    {
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "GetRoute/?Origin={Origin}&Destination={Destination}", ResponseFormat = WebMessageFormat.Json)]
        FlightsRestAPIResult GetShortestRoute(string Origin, string Destination);

    }
}