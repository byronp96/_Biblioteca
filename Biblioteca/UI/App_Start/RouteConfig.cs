using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Biblioteca",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Biblioteca", action = "Biblioteca", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "IniciarSesion",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Entrar", action = "IniciarSesion", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Registrarse",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Entrar", action = "Registrarse", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "AdministracionUsuario",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "AdministracionUsuario", action = "Administracion_Usuario", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "AdministracionCliente",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "AdministracionCliente", action = "Administracion_Cliente", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Categoria",
               url: "{controller}/{action}/",
               defaults: new { controller = "Categoria", action = "Edit" }
           );
        }
    }
}
