using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MasterTest;
using System.Data;

namespace Memo
{
    public partial class Memo : Page
    {
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

        protected void HideInput()
        {
            
        }
    }

}