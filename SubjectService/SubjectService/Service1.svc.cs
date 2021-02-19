using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;


namespace SubjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string delete_Subject(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SubjectDB"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM SubjectTable WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.ExecuteNonQuery();
            return ("Subject Deleted");
        }

        public DataSet GetSubject(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SubjectDB"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubjectTable WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", ID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public DataSet GetSubjects()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SubjectTable",
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Priyavardhan\source\repos\SOC_project\SubjectService\SubjectService\App_Data\SubjectDB.mdf;Integrated Security=True;Connect Timeout=30");
            DataSet ds = new DataSet();
            da.Fill(ds, "SubjectTable");
            return ds;
        }


        public string insert_sub(Subject_class sub)
        {
            string msg;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SubjectDB"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into SubjectTable (Subject, Total_lectures, Required_Attendance, Attended_lectures) values (@subject, @total, @required, @attended)", con);
            cmd.Parameters.AddWithValue("@subject", sub.Subject);
            cmd.Parameters.AddWithValue("@total", sub.Total_lectures);
            cmd.Parameters.AddWithValue("@required", sub.Required_attendance);
            cmd.Parameters.AddWithValue("@attended", sub.Attended_lectures);

            int x = cmd.ExecuteNonQuery();
            if (x == 1)
                msg = "Subject Added";
            else
                msg = "Fail";
            return msg;
        }

        public string update_sub(Subject_class sub)
        {
            string msg;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SubjectDB"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE SubjectTable SET Total_lectures=@total, Required_Attendance=@required, Attended_lectures=@attended WHERE Subject=@subject", con);
            cmd.Parameters.AddWithValue("@subject", sub.Subject);
            cmd.Parameters.AddWithValue("@total", sub.Total_lectures);
            cmd.Parameters.AddWithValue("@required", sub.Required_attendance);
            cmd.Parameters.AddWithValue("@attended", sub.Attended_lectures);

            int x = cmd.ExecuteNonQuery();
            if (x == 1)
                msg = "Subject Updated";
            else
                msg = "Fail";
            return msg;
        }

    }
}
