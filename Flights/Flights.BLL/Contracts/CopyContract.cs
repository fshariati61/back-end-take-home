using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.BLL.Contracts
{
    /// <summary>
    /// This class converts the DB entity to service contract entity
    /// </summary>
    public static class CopyContract
    {
        public static DataObjects.Airline CopyAirline(DAL.Airline obj)
        {
            DataObjects.Airline result = null;

            if (obj != null)
            {
                result = new DataObjects.Airline()
                {
                    ID = obj.ID,
                    Name = obj.Name,
                    TwoDigitCode = obj.TwoDigitCode,
                    ThreeDigitCode = obj.ThreeDigitCode,
                    Country = obj.Country
                };
            }

            return result;
        }

        public static DataObjects.Airport CopyAirport(DAL.Airport obj)
        {
            DataObjects.Airport result = null;

            if (obj != null)
            {
                result = new DataObjects.Airport()
                {
                    ID = obj.ID,
                    Name = obj.Name,
                    City = obj.City,
                    Country = obj.Country,
                    IATA3 = obj.IATA3,
                    Latitute = obj.Latitute,
                    Longitude = obj.Longitude
                };
            }

            return result;
        }

        public static DataObjects.Route CopyRoute(DAL.Route obj)
        {
            DataObjects.Route result = null;

            if (obj != null)
            {
                result = new DataObjects.Route()
                {
                    ID = obj.ID,
                    AirlineID = obj.AirlineID,
                    Origin = obj.Origin,
                    Destination = obj.Destination
                };
            }
            return result;
        }
    }
}
