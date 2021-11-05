using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRG252__Project_Group_6
{
    public partial class Login : Form
    {
        private readonly List<string> PersonsL = new List<string>();
        private readonly List<string> PL = new List<string>();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PersonsL.Contains(user_txt.Text) && PL.Contains(pass_txt.Text) && PL[PersonsL.IndexOf(user_txt.Text)] == pass_txt.Text)
            {
                StudentForm std = new StudentForm();
                std.Show();
                Visible = false;
            }
            else
                MessageBox.Show("Incorrect Password or username");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Register std = new Register();
            std.Show();
            Visible = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("Login.txt");
            string L;
            while((L = SR.ReadLine()) != null)
            {
                string[] components = L.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                PersonsL.Add(components[0]);
                PL.Add(components[1]);

            }
            SR.Close();

        }
    }
}
