using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form4 : Form
    {
       
        public Form4()
        {
            InitializeComponent();
           
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            if (loginUser.role == "1")
            {
                Users.Visible = false;            
            }
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            Form f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            Form f4 = new Form5();
            f4.Show();
            this.Hide();
        }
        private void Users_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

    }
}
