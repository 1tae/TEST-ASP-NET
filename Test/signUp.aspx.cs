using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MasterTest;
using Test;

namespace SignUp
{
    public partial class SignUp : System.Web.UI.Page
    {
        SiteMaster ss = new SiteMaster();
        private SqlConnection con = Global.conn;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender,EventArgs e)
        {
            string id = txtID.Text;

            bool bCheck = true;
            string check_messsge = "";

            if(id.Trim().Length == 0)
            {
                bCheck = false;
                check_messsge = "아이디를 입력해주세요";
            }
            else if (!CheckStep2(id))
            {
                bCheck = false;
                check_messsge = "공백없이 영문/숫자만 가능합니다.";
            }
            else if (id.Length < 4 || id.Length > 12)
            {
                bCheck = false;
                check_messsge = "4~12자로 정해주세요";
            }

            if (bCheck)
            {
                string query = "SELECT COUNT(*) FROM WT_TEST_MEM WHERE TEST_USER_ID ='" + id +"'";
                int result = (int)ss.getSingleQueryResult(query);

                if(result > 0)
                {
                    bCheck = false;
                    check_messsge = "이미 등록된 ID입니다";
                }
                else
                {
                    lblCheckResult.ForeColor = System.Drawing.Color.Blue;
                    check_messsge = "사용할 수 있는 ID입니다.";
                    hdnCheckID.Value = "1";
                }
            }
            else
            {
                lblCheckResult.ForeColor = System.Drawing.Color.Red;
                hdnCheckID.Value = "";
            }

            lblCheckResult.Text = check_messsge;
        }

        bool CheckStep2(string text)
        {
            int k = 0;

            foreach(char c in text)
            {
                if ((0x61 <= c && c < 0x7A) || (0x41 <=c && c <= 0x5A))
                {
                    k++;
                }else if (0x30 <= c && c <= 0x39)
                {
                    k++;
                }
            }

            if(k != text.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnJoin_Click(object sender,EventArgs e)
        {
            string pwd = txtPass.Text.Trim();
            string nick = txtNick.Text.Trim();

            bool bChecked = true;
            string msg = "";

            if (!hdnCheckID.Value.Equals("1"))
            {
                bChecked = false;
                msg = "아이디 중복확인을 해주세요";
            }
            else if(pwd.Length == 0)
            {
                bChecked = false;
                msg = "비밀번호를 입력하세요";
            }
            else if(nick.Length == 0)
            {
                bChecked = false;
                msg = "닉네임을 입력하세요";
            }

            if (bChecked)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("PR_TEST_T02", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USER_ID", txtID.Text);
                cmd.Parameters.AddWithValue("@USER_PWD", pwd);
                cmd.Parameters.AddWithValue("@NICKNAME", nick);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("/login");
            }
            else
            {
                lblJoinResult.ForeColor = System.Drawing.Color.Red;
                lblJoinResult.Text = msg;
            }
        }
    }
}