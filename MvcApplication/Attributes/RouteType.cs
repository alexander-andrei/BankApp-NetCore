using System;
using Microsoft.AspNetCore.Routing;

namespace MvcApplication.Attributes
{
    public class RouteType : System.Attribute
    {
        private string _type;

        public RouteType(string type)
        {
            _type = type;
        }
    }
}