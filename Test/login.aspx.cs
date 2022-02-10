using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MasterTest;
using Test;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {

        SiteMaster ss = new SiteMaster();
        private SqlConnection con = Global.conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login_id"] != null)
            {
                Response.Redirect("/default");
            }
        }

        protected void LoginClick(object sender, EventArgs e)
        {
            string id = userId.Text;
            string pwd = userPwd.Text;

            SqlCommand cmd = new SqlCommand("PR_TEST_T03", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("USER_ID",id);
            cmd.Parameters.AddWithValue("USER_PWD", pwd);

            con.Open();
            SqlDataReader data =  cmd.ExecuteReader();

            while (data.Read())
            {
                Session.Add("login_seq", data[0]);
                Session.Add("login_id",data[1]);
                Session.Add("login_nick", data[2]);
            }
            con.Close();

            Response.Redirect("/default");
        }
    }
}