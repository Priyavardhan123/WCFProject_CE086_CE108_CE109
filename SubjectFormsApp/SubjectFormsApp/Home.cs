using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubjectFormsApp
{
    public partial class Home : Form
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        public Home()
        {
            InitializeComponent();
            DataSet ds = client.GetSubjects();
            listBox1.DataSource = ds.Tables[0].DefaultView;
            listBox1.DisplayMember = "Subject";
            listBox1.ValueMember = "ID";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_subject add = new Add_subject();
            add.Show();
        }

        public static string Subject_choosen { get; internal set; }
        private void button2_Click(object sender, EventArgs e)
        {
            Subject_choosen = listBox1.SelectedValue.ToString();
            Calc c = new Calc();
            c.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DataSet ds = client.GetSubjects();
            listBox1.DataSource = ds.Tables[0].DefaultView;
            listBox1.DisplayMember = "Subject";
            listBox1.ValueMember = "ID";
            label2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Subject_choosen = listBox1.SelectedValue.ToString();
            string msg = client.delete_Subject(int.Parse(Subject_choosen));
            label2.Text = msg;
        }
        
    }
}
