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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace OnlShop_App
{
    public partial class BuyProduct : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=OnlMarket_DB;Integrated Security=True");
        public BuyProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from Items_TB", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private int getCount()
        {
            int count = Convert.ToInt32(textBox2.Text);
            return count;
        }

        private int countFromDB()
        {
            int countDB = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select Count from Items_TB where Id = '{textBox1.Text}'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            foreach (DataRow item in dt.Rows)
            {
                countDB =int.Parse(item["Count"].ToString());
            }
            return countDB;
        }
        //private float GetPriceFromDB()
        //{
        //    float price = 0;
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand($"select ItemPrice from Items_TB where Id = '{textBox1.Text}'", conn);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    conn.Close();
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        price = Convert.ToSingle(item["ItemPrice"].ToString());
        //    }
        //    return price;
        //}

        //private void UpdateTB()
        //{
        //    conn.Open();
        //    SqlCommand cmd1 = new SqlCommand($"Update User_TB set User_TB.MoneyOnAcc = User_TB.MoneyOnAcc - Items_TB.ItemPrice where User_TB.Id = '{textBox3.Text}' AND Items_TB.Id = '{textBox1.Text}' ", conn);
        //    cmd1.ExecuteNonQuery();
        //    conn.Close();
        //}

        private void OrderTB()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"insert into OrderDetail_TB(CUsername,ItemId,Count) values('{textBox3.Text}', '{textBox1.Text}','{textBox2.Text}')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (countFromDB() >= getCount())
            {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Update Items_TB set count = count - '{getCount()}' where Id = '{textBox1.Text}'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            OrderTB();
            }
            else
                MessageBox.Show("Uppppssss... Incorrect Count");
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Form1 form = new Form1();
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand($"select * from User_TB", conn);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    dataGridView2.DataSource = dt;
        //    conn.Close();
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.ShowDialog();
        }
    }
}
