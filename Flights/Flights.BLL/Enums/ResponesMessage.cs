using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Flights.BLL.Enums
{
    /// <summary>
    /// Enumaration class containing the response messages
    /// </summary>
    public class ResponesMessage
    {
        [DataContract]
        public enum Message
        {
            [EnumMember]
            [Description("The path is returned successfully")]
            Successful,

            [EnumMember]
            [Description("An exception occured")]
            SystemException,

            [EnumMember]
            [Description("The route was not found")]
            RouteNotFound,


            [EnumMember]
            [Description("The origin was not found")]
            InvalidOrigin,

            [EnumMember]
            [Description("The destination was not found")]
            InvalidDestination,


        }
    }
}
