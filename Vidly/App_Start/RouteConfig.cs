using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    "Movies",
            //    "Movies/List",
            //    new { controller = "Movies", action = "Index" }
            ////new { year = @"2015|2016", month = @"\d{2}" }
            ////new { year = @"\d{4}", month = @"\d{2}" }
            //);



            //routes.MapRoute
            //(
            //    name : "Customers",
            //    url : "Customers/Details/{id}",
            //    defaults: new { Controller = "Customer",action ="GetCustomerByID"}
            //);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Movies",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Movies", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
