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

namespace OnlShop_App
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=OnlMarket_DB;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private bool Check_User()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from User_TB where Username = '{textBox1.Text}' AND Password = '{textBox2.Text}'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        //public string GetUserName()
        //{
        //    string username = "";
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand($"select Username from User_TB where Username = '{textBox1.Text}'", conn);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    conn.Close();
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        username = Convert.ToString(item["Username"].ToString());
        //    }
        //    return username;
        //}
        //public string GetPassword()
        //{
        //    string password = "";
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand($"select Password from User_TB where Password = '{textBox2.Text}'", conn);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    conn.Close();
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        password = Convert.ToString(item["Password"].ToString());
        //    }
        //    return password;
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);
            Register register = new Register();
            register.TopLevel = false;
            panel2.Controls.Add(register);
            register.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuyProduct product = new BuyProduct();
            if (Check_User() is false)
                MessageBox.Show("Incorrect Username Or Password");
            else
            {
                product.ShowDialog();
            }

        }
    }
}
