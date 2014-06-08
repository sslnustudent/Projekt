using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MyGameCollection.App_Start
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Default", "Hem", "~/Default.aspx");
            routes.MapPageRoute("GameList", "Spelsammling", "~/GameList.aspx");
            routes.MapPageRoute("Details", "spel/{id}", "~/Details.aspx"); 
            routes.MapPageRoute("NewGame", "Nytt spel", "~/NewGame.aspx");
            routes.MapPageRoute("NewUSer", "Registrering", "~/Register.aspx");

        }
    }
}