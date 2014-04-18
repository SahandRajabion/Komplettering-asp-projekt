using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Individuella.App_Start
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("InsertThread", "SkapaTråd", "~/Pages/ThreadPages/Create.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/ThreadPages/Listing.aspx");
            routes.MapPageRoute("ThreadDetails", "thread/{id}", "~/Pages/ThreadPages/Details.aspx");
            routes.MapPageRoute("Error", "Serverfel", "~/Pages/Shared/Errorpage.aspx");
            routes.MapPageRoute("Edit", "Redigera/{id}", "~/Pages/ThreadPages/Edit11.aspx");
            
            
        }
















    }
}