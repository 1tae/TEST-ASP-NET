using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MasterTest;
using Test;

namespace TestPage
{

    public partial class TestPage : Page
    {
        private SqlConnection con = Global.conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblResult.Text = "버튼을 눌러주세요.";
            }
        }
        
        protected void Button1_Click(Object sender, EventArgs e)
        {
            TestTable.Rows.Clear();
            lblResult.Text = "초기화 됨!";

            Response.Clear();

        }

        protected void Button2_Click(Object sender, EventArgs e)
        {
            

            Button btn = (Button)sender;
            int page = 1;
            try
            {
                page = Int32.Parse(Request.Form.Get("Button2"));
                if(page < 1)
                {
                    page = 1;
                }
            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
                page = 1;
            }
            lblResult.Text = Request.Form["btn2"] +"1";
            getMenuList(2);

        }

        public void getMenuList(int page)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("PR_TEST_T01", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PAGE", page);
            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                TableRow tr = new TableRow();
                for (int i = 1; i < 7; i++)
                {
                    TableCell td = new TableCell();
                    td.Text = " " + data[i];
                    tr.Cells.Add(td);
                }
                TestTable.Rows.Add(tr);
            }
            //lblResult.Text = "조회 완료";

            data.Close();
            con.Close();
        }

       
    }
}