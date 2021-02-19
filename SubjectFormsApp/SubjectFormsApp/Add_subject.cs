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
    public partial class Add_subject : Form
    {
        public Add_subject()
        {
            InitializeComponent();
        }

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        private void button1_Click(object sender, EventArgs e)
        {
            Subject_class sub = new Subject_class();
            sub.Subject = textBox1.Text;
            sub.Total_lectures = Convert.ToInt32(textBox2.Text);
            sub.Required_attendance = float.Parse(textBox3.Text);
            sub.Attended_lectures = Convert.ToInt32(textBox4.Text);

            if (sub.Attended_lectures > sub.Total_lectures)
            {
                label6.Text = "Attended Lectures cannot be more than Total lectures";
                label6.ForeColor = Color.Red;
            }
            else
            {
                string r = client.insert_sub(sub);
                label6.Text = r.ToString();
                if (label6.Text == "Subject Added")
                {
                    label6.ForeColor = Color.LimeGreen;
                }
                else
                    label6.ForeColor = Color.Red;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox4.Text) < Convert.ToInt32(textBox2.Text))
            {
                textBox4.Text = (Convert.ToInt32(textBox4.Text) + 1).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox4.Text) > 0)
            {
                textBox4.Text = (Convert.ToInt32(textBox4.Text) - 1).ToString();
            }
        }
        
    }
}
