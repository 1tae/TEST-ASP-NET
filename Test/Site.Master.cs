using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using Test;

namespace MasterTest
{
    public partial class SiteMaster : MasterPage
    {
        private SqlConnection con = Global.conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_id"] == null)
            {
                Response.Redirect("/login");
            }
            else
            {
                login_done.Visible = true;
                lblNick.Text = (string)Session["login_nick"];
            }
        }

        public DataTable getNoneParamsQueryResult(string Query)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();

            return ds.Tables[0];
        }

        public object getSingleQueryResult(string Query)
        {
            con.Open();
            SqlCommand da = new SqlCommand(Query, con);
            object return_val = null;
            return_val = da.ExecuteScalar();
            con.Close();

            return return_val;
        }

        public void ExcuteQuery(string Query)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Logout(object sender,EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/login");
        }
    }

}