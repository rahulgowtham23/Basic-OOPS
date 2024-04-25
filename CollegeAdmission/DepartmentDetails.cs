using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    /// <summary>
    /// Class DepartmentDetails used to create instance for student <see cref="StudentDetails" />
    /// </summary>
    public class DepartmentDetails
    {


        /// <summary>
        /// Static Field s_departmentId used to autoincrement DepartmentId of the instance of <see cref="StudentDetails" />
        /// </summary>
        private static int s_departmentId = 100;    //field


        /// <summary>
        /// DepartmentId property used to hold a Department's Id of instance of <see cref="StudentDetails"/> 
        /// </summary>
        public string DepartmentId { get;}  //Property


        /// <summary>
        /// DepartmentName property used to hold a DepartmentName of instance of <see cref="StudentDetails"/> 
        /// </summary>
        public string DepartmentName { get; set; }


        /// <summary>
        /// NoOfSeats property used to hold a no of seats of instance of <see cref="StudentDetails"/> 
        /// </summary>
        public int NoOfSeats { get; set; }




        /// <summary>
        /// Constructor DepartmentDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="noOfSeats"></param>

        public DepartmentDetails(string departmentName,int noOfSeats){

            s_departmentId++;
            DepartmentId = "DID"+s_departmentId;
            DepartmentName = departmentName;
            NoOfSeats = noOfSeats;
        }


    }
}