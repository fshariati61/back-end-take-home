using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flights.DAL;

namespace Flights.BLL
{
    public class RoutingBLL
    {
        public static List<Contracts.DataObjects.Airline> GetAirlines()
        {
            List<Contracts.DataObjects.Airline> result = new List<Contracts.DataObjects.Airline>();
            using (var db = new DAL.FlightsEntities())
            {
                var airlines = db.Airlines.ToList();

                foreach (var airline in airlines)
                {
                    result.Add(Contracts.CopyContract.CopyAirline(airline));
                }

                return result;
            }
        }

        public static Contracts.DataObjects.Airline GetAirline(string twoDigitCode)
        {
            Contracts.DataObjects.Airline result = new Contracts.DataObjects.Airline();
            using (var db = new DAL.FlightsEntities())
            {
                var airline = db.Airlines.Where(t => t.TwoDigitCode == twoDigitCode).FirstOrDefault();

                return Contracts.CopyContract.CopyAirline(airline);
            }
        }

        public static List<DAL.Route> GetAllRoutes()
        {
            List<DAL.Route> result = new List<DAL.Route>();
            using (var db = new DAL.FlightsEntities())
            {
                return (db.Routes.ToList());
            }
        }


        public static List<Contracts.DataObjects.Route> GetRoutes(string origin, string destination)
        {
            List<Contracts.DataObjects.Route> result = new List<Contracts.DataObjects.Route>();
            using (var db = new DAL.FlightsEntities())
            {
                var routes = db.Routes.Where(r => r.Origin == origin && r.Destination == destination).ToList();

                foreach (var route in routes)
                {
                    result.Add(Contracts.CopyContract.CopyRoute(route));
                }

                return result;
            }

        }

        public static List<Contracts.DataObjects.Route> GetRoutes(string origin)
        {
            List<Contracts.DataObjects.Route> result = new List<Contracts.DataObjects.Route>();
            using (var db = new DAL.FlightsEntities())
            {
                var routes = db.Routes.Where(r => r.Origin == origin).ToList();

                foreach (var route in routes)
                {
                    result.Add(Contracts.CopyContract.CopyRoute(route));
                }
                return result;
            }

        }

        public static int GetRoutesCount()
        {
            using (var db = new DAL.FlightsEntities())
            {
                return (db.Routes.ToList().Count);
            }
        }

  
        /// <summary>
        /// Returns the shortetst route between the origin and destination
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns>FlightsRestAPIResult which contains the message and the path</returns>
        public static BLL.Contracts.FlightsRestAPIResult GetShortestRoute(string origin, string destination)
        {
            Contracts.FlightsRestAPIResult result = new Contracts.FlightsRestAPIResult();
            try
            {
                 using (var db = new DAL.FlightsEntities())
                {
                    var routes = db.Routes.Where(r => r.Origin == origin).ToList();
                     if (routes.Count() < 1)
                    {
                        result.Message = Enums.ResponesMessage.Message.InvalidOrigin.ToString();
                        return (result);
                    }

                    var desRoutes = db.Routes.Where(r => r.Destination == destination).ToList();
                    if (desRoutes.Count() < 1)
                    {
                        result.Message = Enums.ResponesMessage.Message.InvalidDestination.ToString();
                        return (result);
                    }
                }


                Graph g = new Graph();
                List<DAL.Route> lstRoute = GetAllRoutes();
                foreach (var route in lstRoute)
                {
                    g.AddEdge(route.Origin, route.Destination);
                }

                result.Message = Enums.ResponesMessage.Message.Successful.ToString();
                result.Path = g.PrintAllPaths(origin, destination);
                return (result);
            }
            catch
            {
                result.Message = Enums.ResponesMessage.Message.SystemException.ToString();
                return (result);
            }
        }

    }

}


