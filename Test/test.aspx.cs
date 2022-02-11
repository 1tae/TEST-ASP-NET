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
        SiteMaster ss = new SiteMaster();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lblResult.Text = "버튼을 눌러주세요.";
                nowPage.Value = "1";
                nowPageInfo.Text = "1";

                string query = "SELECT CONVERT(INT,CEILING(COUNT(*)/20.0)) FROM MENU";
                int last = (int)ss.getSingleQueryResult(query);


                lastPage.Value = last+"";
                if(last < 2)
                {
                    btnNext.Visible = false;
                }
                getMenuList();
            }
        }
        
        protected void Button1_Click(Object sender, EventArgs e)
        {
            TestTable.Rows.Clear();
            lblResult.Text = "초기화 됨!";

            Response.Clear();

        }


        public void getMenuList()
        {
            int page = 1;
            try
            {
                page = Int32.Parse(nowPage.Value);
            }
            catch (Exception)
            {
                page = 1;
            }

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
                nowPage.Value = data[0]+"";
                nowPageInfo.Text = data[0] + "";
            }
            //lblResult.Text = "조회 완료";
            if(Int32.Parse(nowPage.Value) > 1)
            {
                btnBefore.Visible = true;
            }
            else
            {
                btnBefore.Visible = false;
            }

            if (Int32.Parse(nowPage.Value) >= Int32.Parse(lastPage.Value))
            {
                btnNext.Visible = false;
            }
            else
            {
                btnNext.Visible = true;
            }


            data.Close();
            con.Close();
        }

        protected void beforePage(object sender, EventArgs e)
        {
            int p = Int32.Parse(nowPage.Value);
            if(p > 1)
            {
                nowPage.Value = (p - 1) + "";
            }
            getMenuList();
        }

        protected void nextPage(object sender,EventArgs e)
        {
            int p = Int32.Parse(nowPage.Value);
            if (p < Int32.Parse(lastPage.Value))
            {
                nowPage.Value = (p + 1) + "";
            }
            getMenuList();
        }

        abstract class TestObject
        {
            public int atk = 10;

            public TestObject()
            {

            }

            public TestObject(int atk)
            {
                this.atk = atk;
            }


            public virtual void Attack()
            {
            }

            public abstract void Deff();
        }


        class Knife : TestObject
        {
            public Knife(int atk)
            {
                this.atk = atk;
            }

            public override void Attack()
            {
                Console.WriteLine("kkk");
            }

            public override void Deff()
            {
                Console.WriteLine("DDD");
            }

            public static Knife operator +(Knife a, Knife b)
            {
                return new Knife(a.atk + b.atk);
            }
        }

        struct StructStudent
        {
            public string name;
            public void Display()
            {
                Console.WriteLine(name);
            }
        }

        class ClassStudent
        {
            public string name;
            public void Display()
            {
                Console.WriteLine(name);
            }
        }
        class Program
        {
            static void Change(StructStudent ss, ClassStudent cs)
            {
                ss.name = "After";
                cs.name = "After";
            }
            static void Main(string[] args)
            {
                StructStudent ss;
                ss.name = "Before";
                ClassStudent cs = new ClassStudent();
                cs.name = "Before";

                Change(ss, cs);

                ss.Display();
                cs.Display();
            }
        }
    }

    class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }

    class ExceptionTest
    {
        static void Main(string[] args)
        {
            try
            {
                int a;
                int b;
                a = Int32.Parse(Console.ReadLine());
                b = Int32.Parse(Console.ReadLine());

                if (b == 0)
                {
                    throw new MyException("0으로 나눌수없어요~");
                }

                Console.WriteLine(a / b);
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

}