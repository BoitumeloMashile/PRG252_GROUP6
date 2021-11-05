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
using System.Collections;

namespace PRG252__Project_Group_6
{
    public partial class ModulesForm : Form
    {
        public ModulesForm()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void ModulesForm_Load(object sender, EventArgs e)
        {
            Modules rl = new Modules();
            dataGridView1.DataSource = rl.PopulateModules();
            LoadData();
        }
        BindingSource recordSource = new BindingSource();
        public void LoadData()
        {
            

            recordSource.DataSource = new Modules().PopulateModules();
            dataGridView1.DataSource = recordSource;
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string moduleCode = txtMcodes.Text;
            string moduleName = txtMName.Text;
            string moduleDescription = txtMDescription.Text;
            string links = tctMLinks.Text;
            
            

            Modules md = new Modules();
            md.InsertModules(moduleCode, moduleName, moduleDescription, links);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = md.PopulateModules();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string moduleCode = ((Modules)bs.Current).ModuleCode;
            ArrayList dataParams = new ArrayList();
            dataParams.Add(txtCode.Text);
            dataParams.Add(txtName.Text);
            dataParams.Add(txtDescription.Text);
            dataParams.Add(txtLinks.Text);
            new Modules().UpdateModules(dataParams);
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Modules label = (Modules)recordSource.Current;
            string moduleCode = label.ModuleCode;
            Modules md = new Modules();
            bs.DataSource = md.GetSpecificModules(moduleCode);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modules md = (Modules)bs.Current;
            md.DeleteModulesFromDB(md.ModuleCode);
            LoadData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StudentForm std = new StudentForm();
            std.Show();
            Visible = false;

        }
    }
}
