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
using System.IO;

namespace PRG252__Project_Group_6
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           using(StreamWriter WR = new StreamWriter("Login.txt", true))
            {
                WR.WriteLine(email_txt.Text + " " + name_txt.Text + " " + pas_txt.Text);
                WR.Close();

                Login std = new Login();
                std.Show();
                Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login std = new Login();
            std.Show();
            Visible = false;
        }
    }
}
