using System;
using System.Web.UI;
using System.Web;
using System.Data.SqlClient;
using MasterTest;
using System.Data;
using Test;

namespace Memo
{
    public partial class Memo : Page
    {
        private SqlConnection con = Global.conn;
        SiteMaster ss = new SiteMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                readMemo();
            }

        }

        protected void Save_Click(Object sender, EventArgs e)
        {
            
            string title = MemoTitle.Text;
            string dr = Description.Text;
            string id = (string)Session["login_id"];

            if(title.Length == 0 || dr.Length == 0)
            {
                throw new Exception("명령어를 입력해주세요");
            }

            string query = "INSERT INTO WT_MEMO (TEST_SEQ,TEST_TITLE,TEST_DESCRIPTION,TEST_USER_ID) VALUES (NEXT VALUE FOR testMemoSeq ,'" + title + "','" + dr + "','"+ id +"')";
            ss.ExcuteQuery(query);

            MemoTitle.Text = "";
            Description.Text = "";
            Response.Redirect("/memo");
        }

        protected void readMemo()
        {

            string query = "select TEST_SEQ,TEST_TITLE AS 제목,TEST_DESCRIPTION AS 내용, TEST_USER_ID AS 작성자 from WT_MEMO";
            DataTable dt = ss.getNoneParamsQueryResult(query);

            listData.DataSource = dt;
            listData.DataBind();
        }

        protected void Search(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("PR_TEST_T04", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("search", searchText.Text);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            listData.DataSource = dt;
            listData.DataBind();

            cmd.Dispose();

            con.Close();

        }


    }

}