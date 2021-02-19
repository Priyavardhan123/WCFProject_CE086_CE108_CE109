using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SubjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string insert_sub(Subject_class sub);

        [OperationContract]
        string update_sub(Subject_class sub);

        [OperationContract]
        DataSet GetSubjects();

        [OperationContract]
        DataSet GetSubject(int ID);

        [OperationContract]
        string delete_Subject(int ID);


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Subject_class
    {
        string subject = string.Empty;
        int total_lec = 0;
        float req_attendance = 0;
        int attended = 0;

        [DataMember]
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        [DataMember]
        public int Total_lectures
        {
            get { return total_lec; }
            set { total_lec = value; }
        }
        [DataMember]
        public float Required_attendance
        {
            get { return req_attendance; }
            set { req_attendance = value; }
        }
        [DataMember]
        public int Attended_lectures
        {
            get { return attended; }
            set { attended = value; }
        }
    }

}
