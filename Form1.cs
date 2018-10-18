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


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // public string strSql = "Data Source=127.0.0.1:3306;Database=korea;User Id=root;Password=0000";

        private void Login_Click(object sender, EventArgs e)
        {
            //sql 데이터베이스 이용 연동
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\meganext\Documents\Data1.mdf;Integrated Security=True;Connect Timeout=30"); //sql 데이터 베이스 연결 객체생성 
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from USERINFO Where USERNAME='"+ID_txt.Text+"'and PASSWORD='"+PW_txt.Text+"'",con); //쿼리문과 C#을 같이
            con.Open();
            DataTable newtable = new DataTable();//userifo를 이용해 새로운 테이블
            //아이디와 패스워드가 맞다면 newtable을 1로 반환 아니면 0으로 반환
            sda.Fill(newtable);

            if (newtable.Rows[0][0].ToString() == "1")//로그인이 성공할 경우
            {
                this.Hide();

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else//로그인 실패시
            {
                MessageBox.Show("아이디와 비밀번호를 확인해주세요");
            }          
            
        }

        private void JOIN_Click(object sender, EventArgs e)
        {
            Join join = new Join();
            join.Show();
        }
    }
}
