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
<<<<<<< HEAD
//git branch
======= 
//remote ?�정
>>>>>>> 23f642bb4a5755b05c6d410c88f41985c23e01a5

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // public string strSql = "Data Source=127.0.0.1:3306;Database=korea;User Id=root;Password=0000";

        private void Login_Click(object sender, EventArgs e)
        {
            //sql ?�이?�베?�스 ?�용 ?�동
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\meganext\Documents\Data1.mdf;Integrated Security=True;Connect Timeout=30"); //sql ?�이??베이???�결 객체?�성 
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from USERINFO Where USERNAME='"+ID_txt.Text+"'and PASSWORD='"+PW_txt.Text+"'",con); //쿼리문과 C#??같이
            con.Open();
            DataTable newtable = new DataTable();//userifo�??�용???�로???�이�?
            //?�이?��? ?�스?�드가 맞다�?newtable??1�?반환 ?�니�?0?�로 반환
            sda.Fill(newtable);

            if (newtable.Rows[0][0].ToString() == "1")//로그?�이 ?�공??경우
            {
                this.Hide();

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else//로그???�패??
            {
                MessageBox.Show("?�이?��? 비�?번호�??�인?�주?�요");
            }          
            
        }

        private void JOIN_Click(object sender, EventArgs e)
        {
            Join join = new Join();
            join.Show();
        }
    } //zzzzzzzzzzzzzzzzzzzzzzzzzzzzz
}
