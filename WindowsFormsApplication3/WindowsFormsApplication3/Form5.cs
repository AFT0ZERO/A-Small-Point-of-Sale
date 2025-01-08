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

namespace WindowsFormsApplication3
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\pointOfSale\firstdb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        int ID = 0;
        double total=0;
        public Form5()
        {
            InitializeComponent();
            displaydata();
        }
        private void displaydata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from orders", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }


        //copy data from select row in gridview to the textboxes
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            ID = Convert.ToInt32(textBox1.Text);
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


        }
        //clear all data on the textboxes
        private void cleardata()
        {
            DateTime dateTime = DateTime.Now;
           
            textBox1.Text = "";
            textBox2.Text = "";
           // textBox3.Text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            textBox4.Text = "";
            textBox5.Text = "";

        }
        //insert new data to table
        private void insert_Click(object sender, EventArgs e)
        {
            con.Open();

            string getProductcmd = "select * from product where product_id=@pid";
            cmd = new SqlCommand(getProductcmd, con);
            cmd.Parameters.AddWithValue("@pid", textBox2.Text);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read() && textBox5.Text=="")
            {
                double unit_price = Convert.ToDouble(reader.GetValue(3));
                double qty = Convert.ToDouble(textBox4.Text);
                textBox5.Text = (unit_price*qty).ToString();
            }
            con.Close();
            con.Open();
            string insertcmd = "insert into orders (c_id, p_id, qty, total_price) values(@cid,@pid,@qty,@price)";
            cmd = new SqlCommand(insertcmd, con);
            cmd.Parameters.AddWithValue("@cid", textBox1.Text);
            cmd.Parameters.AddWithValue("@pid", textBox2.Text);
            //cmd.Parameters.AddWithValue("@time", textBox3.Text);
            cmd.Parameters.AddWithValue("@qty", textBox4.Text);
            cmd.Parameters.AddWithValue("@price", textBox5.Text);

            cmd.ExecuteNonQuery();
            total += Convert.ToDouble(textBox5.Text);
            cleardata();
            con.Close();
            displaydata();
            MessageBox.Show("Data inserted correctly");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cleardata();
        }
        //update
        private void update_Click(object sender, EventArgs e)
        {
            con.Open();
            string updatecmd = "update orders set qty=@qty, total_price=@price where c_id=@cid and p_id=@pid and order_time=@time";
            cmd = new SqlCommand(updatecmd, con);
            cmd.Parameters.AddWithValue("@cid", textBox1.Text);
            cmd.Parameters.AddWithValue("@pid", textBox2.Text);
            cmd.Parameters.AddWithValue("@time", textBox3.Text);
            cmd.Parameters.AddWithValue("@qty", textBox4.Text);
            cmd.Parameters.AddWithValue("@price", textBox5.Text);
            cmd.ExecuteNonQuery();
            cleardata();
            con.Close();
            displaydata();
            MessageBox.Show("Data Updated correctly");
        }
        // delete method
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string Deletecmd = "delete from orders where c_id=@cid and p_id=@pid and order_time=@time";
            cmd = new SqlCommand(Deletecmd, con);
            cmd.Parameters.AddWithValue("@cid", textBox1.Text);
            cmd.Parameters.AddWithValue("@pid", textBox2.Text);
            cmd.Parameters.AddWithValue("@time", textBox3.Text);
            cmd.ExecuteNonQuery();
            cleardata();
            con.Close();
            displaydata();
            MessageBox.Show("Data Deleted correctly");
        }
        //Select Method
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string Selectcmd = "select * from orders where c_id=@cid and p_id=@pid";
            cmd = new SqlCommand(Selectcmd, con);
            cmd.Parameters.AddWithValue("@cid", textBox1.Text);
            cmd.Parameters.AddWithValue("@pid", textBox2.Text);
            SqlDataReader reader1;
            reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                textBox3.Text = reader1.GetValue(2).ToString();
                textBox4.Text = reader1.GetValue(3).ToString();
                textBox5.Text = reader1.GetValue(4).ToString();
            }
            else
            { MessageBox.Show("NO Data Found"); }
            con.Close();
            displaydata();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f_b = new Form4();
            f_b.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your total is : " + total.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your total is : " + total.ToString() +"\n order Finished");
            total = 0;         
        }
    }
}
