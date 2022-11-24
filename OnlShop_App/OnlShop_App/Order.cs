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
    public partial class Order : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=OnlMarket_DB;Integrated Security=True");
        public Order()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from OrderDetail_TB", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private float GetPriceFromDB()
        {
            float price = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select ItemPrice from Items_TB where Id = ItemId ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            foreach (DataRow item in dt.Rows)
            {
                price = Convert.ToSingle(item["ItemPrice"].ToString());
            }
            return price;
        }

        private void updateClientInfo()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Update User_TB set MoneyOnAcc = MoneyOnAcc - '{GetPriceFromDB()}' where Username = '{textBox2.Text}'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete from OrderDetail_TB where Id = '{textBox1.Text}'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
