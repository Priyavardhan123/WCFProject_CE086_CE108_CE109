using SubjectFormsApp.ServiceReference1;
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
    public partial class Calc : Form
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
        public Calc()
        {
            InitializeComponent();
        }

        private void Calc_Load_1(object sender, EventArgs e)
        {
            DataSet ds = client.GetSubject(int.Parse(Home.Subject_choosen));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                label1.Text = ds.Tables[0].Rows[i]["Subject"].ToString();
                textBox1.Text = ds.Tables[0].Rows[i]["Total_lectures"].ToString();
                textBox2.Text = (ds.Tables[0].Rows[i]["Required_Attendance"]).ToString();
                textBox3.Text = ds.Tables[0].Rows[i]["Attended_lectures"].ToString();
            }
            int total = Convert.ToInt32(textBox1.Text);
            int req = (Convert.ToInt32(textBox2.Text) * total) / 100;
            int attended = Convert.ToInt32(textBox3.Text);

            if (attended > total)
            {
                label6.Text = "Attended Lectures cannot be more than Total lectures";
                label6.ForeColor = Color.Red;
            }
            else if (req - attended > 0)
                label6.Text = "You need to attend " + (req - attended).ToString() + " more lectures to achieve " + textBox2.Text + "% attendance";
            else
                label6.Text = "Bravo !!! " + textBox2.Text + "% attendance has been achieved.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(textBox1.Text);
            int req = (Convert.ToInt32(textBox2.Text) * total) / 100;
            int attended = Convert.ToInt32(textBox3.Text);

            Subject_class sub = new Subject_class();
            sub.Subject = label1.Text;
            sub.Total_lectures = Convert.ToInt32(textBox1.Text);
            sub.Required_attendance = float.Parse(textBox2.Text);
            sub.Attended_lectures = Convert.ToInt32(textBox3.Text);

            if (attended > total)
            {
                label6.Text = "Attended Lectures cannot be more than Total lectures";
                label6.ForeColor = Color.Red;
            }
            else if (req - attended > 0)
            {
                label6.Text = "You need to attend " + (req - attended).ToString() + " more lectures to achieve " + textBox2.Text + "% attendance";
                string r = client.update_sub(sub);
                label7.Text = r.ToString();
            }
            else
            {
                label6.Text = "Bravo !!! " + textBox2.Text + "% attendance has been achieved.";
                string r = client.update_sub(sub);
                label7.Text = r.ToString();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox1.Text))
            {
                textBox3.Text = (Convert.ToInt32(textBox3.Text) + 1).ToString();
                label7.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) > 0)
            {
                textBox3.Text = (Convert.ToInt32(textBox3.Text) - 1).ToString();
                label7.Text = "";
            }
        }
    }
}
