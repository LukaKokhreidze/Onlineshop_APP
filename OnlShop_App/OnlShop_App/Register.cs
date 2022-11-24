using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlShop_App
{
    public partial class Register : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=OnlMarket_DB;Integrated Security=True");
        public Register()
        {
            InitializeComponent();
        }

        private bool Check_User()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from User_TB where Username = '{textBox1.Text}'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check_User())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Insert Into User_TB(Username,Password,Name,Surname,MoneyOnAcc) values('{textBox1.Text}', '{textBox2.Text}', '{textBox4.Text}', '{textBox3.Text}','{textBox5.Text}') ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
