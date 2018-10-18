using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginForm
{
    public partial class Join : Form
    {
        public Join()
        {
            InitializeComponent();
        }

        private Boolean idCheckd = false;
        private Boolean pwCheckd = false;
        Form1 form1 = new Form1();

        private void pwCheck()
        {
            if (pwjoin_txt.Text == pwcheck_txt.Text)
            {
                pwCheckd = true;
            }
            else
            {
                pwCheckd = false;
            }
        }


        private void idcheckbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\meganext\Documents\Data1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * FROM USERINFO";
            SqlDataReader sr = cmd.ExecuteReader();
            
            // var MConn = new MySqlConnection(form1.strSql);
            // MConn.Open();
            if (!idCheckd)
            {

               string sql = "select USERNAME, PASSWORD from USERINFO where USERNAME='" + idjoin_txt.Text + "'";

               var Comm = new MySqlCommand(sql);
               var myRead = Comm.ExecuteReader();
                if(myRead.HasRows)
                {
                    idCheckd = false;
                    label1.ForeColor = Color.Red;
                    label1.Text = "아이디 중복";

                }
                else
                {
                    idCheckd = true;
                    label1.ForeColor = Color.Blue;
                    label1.Text = "OK확인";
                }
                con.Close();
            }
            

        }

        private void OK_click(object sender, EventArgs e)
        {
            pwCheck();
            if (pwCheckd)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\meganext\Documents\Data1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * FROM USERINFO";
                SqlDataReader sr = cmd.ExecuteReader();
                string sql = "insert into USERINFO(USERNAME, PASSWORD) values('" + idjoin_txt.Text + "','" + pwjoin_txt.Text + "')";
                var Comm = new SqlCommand(sql);
                int i = Comm.ExecuteNonQuery();
                

                //var MConn = new MySqlConnection(form1.strSql);
                // MConn.Open();
                // string sql = "insert into USERINFO(USERNAME, PASSWORD) values('" + idjoin_txt.Text + "','" + pwjoin_txt.Text + "')";
                // var Comm = new MySqlCommand(sql, MConn);
                //int i = Comm.ExecuteNonQuery();
                //MConn.Close();

                if (i==1)
                {
                    MessageBox.Show("가입완료", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("비밀번호를 확인하세요", "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            
        }

    }
}
