﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CafeSystem1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DHRUTI\SQLEXPRESS;Initial Catalog=Cafedb1;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder guest=new GuestOrder();
            guest.Show();
        }
        public static string user;
        private void button1_Click(object sender, EventArgs e)
        {

            user=UnameTb.Text;
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Please enter the fields!");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UsersTbl where Uname='" + UnameTb.Text + "' and Upassword = '" + PasswordTb.Text + "'",Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                       UserOrder uOrder = new UserOrder();
                       uOrder.Show();
                       this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
                Con.Close();
            }
        }
    }
}
