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
            //sql �����ͺ��̽� �̿� ����
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\meganext\Documents\Data1.mdf;Integrated Security=True;Connect Timeout=30"); //sql ������ ���̽� ���� ��ü���� 
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from USERINFO Where USERNAME='"+ID_txt.Text+"'and PASSWORD='"+PW_txt.Text+"'",con); //�������� C#�� ����
            con.Open();
            DataTable newtable = new DataTable();//userifo�� �̿��� ���ο� ���̺�
            //���̵�� �н����尡 �´ٸ� newtable�� 1�� ��ȯ �ƴϸ� 0���� ��ȯ
            sda.Fill(newtable);

            if (newtable.Rows[0][0].ToString() == "1")//�α����� ������ ���
            {
                this.Hide();

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else//�α��� ���н�
            {
                MessageBox.Show("���̵�� ��й�ȣ�� Ȯ�����ּ���");
            }          
            
        }

        private void JOIN_Click(object sender, EventArgs e)
        {
            Join join = new Join();
            join.Show();
        }
    }
}
