namespace WindowsFormsApplication3
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Customers = new System.Windows.Forms.Button();
            this.Products = new System.Windows.Forms.Button();
            this.Users = new System.Windows.Forms.Button();
            this.Orders = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Customers
            // 
            this.Customers.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Customers.Location = new System.Drawing.Point(246, 63);
            this.Customers.Name = "Customers";
            this.Customers.Size = new System.Drawing.Size(183, 74);
            this.Customers.TabIndex = 0;
            this.Customers.Text = "Customers";
            this.Customers.UseVisualStyleBackColor = true;
            this.Customers.Click += new System.EventHandler(this.Customers_Click);
            // 
            // Products
            // 
            this.Products.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Products.Location = new System.Drawing.Point(246, 143);
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(183, 74);
            this.Products.TabIndex = 1;
            this.Products.Text = "Products";
            this.Products.UseVisualStyleBackColor = true;
            this.Products.Click += new System.EventHandler(this.Products_Click);
            // 
            // Users
            // 
            this.Users.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Users.Location = new System.Drawing.Point(246, 303);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(183, 74);
            this.Users.TabIndex = 3;
            this.Users.Text = "Users";
            this.Users.UseVisualStyleBackColor = true;
            this.Users.Click += new System.EventHandler(this.Users_Click);
            // 
            // Orders
            // 
            this.Orders.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Orders.Location = new System.Drawing.Point(246, 223);
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(183, 74);
            this.Orders.TabIndex = 2;
            this.Orders.Text = "Orders";
            this.Orders.UseVisualStyleBackColor = true;
            this.Orders.Click += new System.EventHandler(this.Orders_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Exit.Location = new System.Drawing.Point(246, 383);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(183, 74);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 596);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.Orders);
            this.Controls.Add(this.Products);
            this.Controls.Add(this.Customers);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Customers;
        private System.Windows.Forms.Button Products;
        private System.Windows.Forms.Button Users;
        private System.Windows.Forms.Button Orders;
        private System.Windows.Forms.Button Exit;
    }
}