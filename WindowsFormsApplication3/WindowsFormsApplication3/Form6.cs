using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\pointOfSale\firstdb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        
        public Form6()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from users where user_name='"+textBox1.Text +"' and password='"+textBox2.Text+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            if (data.Rows.Count == 1)
            {
               loginUser.UserName = data.Rows[0]["user_name"].ToString();
               loginUser.role = data.Rows[0]["user_role"].ToString();

                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
                textBox1.Text = "";
                textBox2.Text = "";
            }


        }
    }
}
