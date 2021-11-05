using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PRG252__Project_Group_6
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            bs.DataSource = new Student().PopulateStudents();
        }

        BindingSource bs = new BindingSource();

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ModulesForm std = new ModulesForm();
            std.Show();
            Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int studentNumber= int.Parse(txtNumber.Text);
            string studentName = txtName.Text;
            string studentSurname = txtSurname.Text;
            int dateOfBirth = int.Parse(txtDOB.Text);
            string gender= textGender.Text;
            int phone= int.Parse(txtPhone.Text);
            string address = txtAddress.Text;
            string moduleCode= txtModuleCode.Text;
            Student student = new Student();
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int studentNumber = ((Student)bs.Current).StudentNumber;
            ArrayList dataParams = new ArrayList();
            dataParams.Add(int.Parse(txtNumber1.Text));
            dataParams.Add(txtName1.Text);
            dataParams.Add(txtSurname1.Text);
            dataParams.Add(int.Parse(txtDOB1.Text));
            dataParams.Add(txtGender1.Text);
            dataParams.Add(int.Parse(txtPhone1.Text));
            dataParams.Add(txtAddress1.Text);
            dataParams.Add(txtModuleCode1.Text);
            dataParams.Add(studentNumber);
            new Student().UpdateStudent(dataParams);
            LoadData();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student student = (Student)bs.Current;
            student.DeleteStudent(student.StudentNumber);
            LoadData();
        }
    }
}
