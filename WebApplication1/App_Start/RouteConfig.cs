using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );



            routes.MapRoute(
                name: "Entrar Usuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblLogins", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Crear_Usuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblLogins/Index", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cliente",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblClients", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "crear Cliente",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblClients/Index/", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblContacts",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblContact", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "crear tblContacts",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblContact/Index/", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblReunions1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblReunions1", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "crear tblReunions1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblReunions1/Index/", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "tblSupport_Tickets",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "tblSupport_Tickets", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "crear tblSupport_Tickets",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tblSupport_Tickets/Index/", action = "Create", id = UrlParameter.Optional }
            );
            




        }
    }
}
