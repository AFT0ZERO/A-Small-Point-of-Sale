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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\pointOfSale\firstdb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        int ID = 0;
        public Form1()
        {
            InitializeComponent();
            displaydata();
        }
        //fill gridview with data from dtabase (cutomer table)
        private void displaydata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
 private void Form1_Load(object sender, EventArgs e)
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

 }
        //clear all data on the textboxes
 private void cleardata()
 {
    textBox1.Text = "";
    textBox2.Text = "";
     textBox3.Text = "";
     textBox4.Text = "";
 }
//insert new data to table
 private void insert_Click(object sender, EventArgs e)
 {
    con.Open();
     string insertcmd = "insert into Customer values(@id,@name,@tel,@gender)";
     cmd = new SqlCommand(insertcmd, con);
     cmd.Parameters.AddWithValue("@id", textBox1.Text);
     cmd.Parameters.AddWithValue("@name", textBox2.Text);
     cmd.Parameters.AddWithValue("@tel", textBox3.Text);
     cmd.Parameters.AddWithValue("@gender", textBox4.Text );
     cmd.ExecuteNonQuery();
     cleardata();
     con.Close();
     displaydata();
     MessageBox.Show("Data inserted correctly");
 }

 private void button1_Click(object sender, EventArgs e)
 {
     cleardata();
 }

 private void label1_Click(object sender, EventArgs e)
 {

 }
        //update
     private void update_Click(object sender, EventArgs e)
     {
     con.Open();
     string updatecmd = "update Customer set customer_name=@name,Telephone=@tel,Gender=@gender where Customer_id=@id";
     cmd = new SqlCommand(updatecmd, con);
     cmd.Parameters.AddWithValue("@id", ID);
     cmd.Parameters.AddWithValue("@name", textBox2.Text);
     cmd.Parameters.AddWithValue("@tel", textBox3.Text);
     cmd.Parameters.AddWithValue("@gender", textBox4.Text );
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
         string Deletecmd = "delete from Customer where Customer_id=@id";
         cmd = new SqlCommand(Deletecmd, con);
         cmd.Parameters.AddWithValue("@id", textBox1.Text);
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
         string Selectcmd = "select * from customer where customer_id=@id";
         cmd = new SqlCommand(Selectcmd, con);
         cmd.Parameters.AddWithValue("@id", textBox1.Text);
         SqlDataReader reader1;
         reader1 = cmd.ExecuteReader();
         if (reader1.Read())
         {
             textBox2.Text = reader1.GetValue(1).ToString();
             textBox3.Text = reader1.GetValue(2).ToString();
             textBox4.Text = reader1.GetValue(3).ToString();
         }
         else
         { MessageBox.Show("NO Data Found"); }
         con.Close();
         displaydata();
       
     }

     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
     {

     }

     private void button5_Click(object sender, EventArgs e)
     {
         Form f_b = new Form4();
         f_b.Show();
         this.Hide();
     }
       
  
    }
}
