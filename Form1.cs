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
//remote ?˜ì •
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
            //sql ?°ì´?°ë² ?´ìŠ¤ ?´ìš© ?°ë™
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\meganext\Documents\Data1.mdf;Integrated Security=True;Connect Timeout=30"); //sql ?°ì´??ë² ì´???°ê²° ê°ì²´?ì„± 
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from USERINFO Where USERNAME='"+ID_txt.Text+"'and PASSWORD='"+PW_txt.Text+"'",con); //ì¿¼ë¦¬ë¬¸ê³¼ C#??ê°™ì´
            con.Open();
            DataTable newtable = new DataTable();//userifoë¥??´ìš©???ˆë¡œ???Œì´ë¸?
            //?„ì´?”ì? ?¨ìŠ¤?Œë“œê°€ ë§ë‹¤ë©?newtable??1ë¡?ë°˜í™˜ ?„ë‹ˆë©?0?¼ë¡œ ë°˜í™˜
            sda.Fill(newtable);

            if (newtable.Rows[0][0].ToString() == "1")//ë¡œê·¸?¸ì´ ?±ê³µ??ê²½ìš°
            {
                this.Hide();

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else//ë¡œê·¸???¤íŒ¨??
            {
                MessageBox.Show("?„ì´?”ì? ë¹„ë?ë²ˆí˜¸ë¥??•ì¸?´ì£¼?¸ìš”");
            }          
            
        }

        private void JOIN_Click(object sender, EventArgs e)
        {
            Join join = new Join();
            join.Show();
        }
    } //zzzzzzzzzzzzzzzzzzzzzzzzzzzzz
}
