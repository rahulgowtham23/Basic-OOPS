using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission


{
    public enum Status{select, Admitted,Cancelled,
        Booked
    }

    public class AdmissionDetails
    {
        private static int s_admissionId =  1000;   //field
        public string AdmissionId { get;}   //property

        public String StudentId { get;}
        public string DepartmentId { get;}
        public DateTime AdmissionDate { get; set; }
        public Status AdmissionStatus { get; set; }


        public AdmissionDetails(string studentId,string departmentId,DateTime admissionDate,Status admissionStatus){
            s_admissionId++;

            AdmissionId = "AID"+s_admissionId;
            StudentId = studentId;
            DepartmentId = departmentId;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }




    }
}