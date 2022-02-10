using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Configuration;

namespace Test
{
    public class Global : HttpApplication
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);

        void Application_Start(object sender, EventArgs e)
        {
            // 애플리케이션 시작 시 실행되는 코드
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }  

        void Session_start(object sender, EventArgs e)
        {
            
        }
    }

   
}