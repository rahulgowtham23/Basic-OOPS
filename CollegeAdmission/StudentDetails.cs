using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    /// <summary>
    /// DataType Gender used to select a instance of <see cref = "StudentDetails" /> Gender Information
    /// </summary>
    public enum Gender{
        Male,
        Female,
        Trasngender
    }	

    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails" />
    /// Refer documentation on <see href= "www.syncfusion.com" />
    /// </summary>

    public class StudentDetails
    {
        /// <summary>
        /// Static Field s_studentId used to autoincrement StudentID of the instance of <see cref="StudentDetails" />
        /// </summary>
        private static int s_studentId = 3000;   //field

        // Auto property
        // Type Prop and press tab

        /// <summary>
        /// StudentId property used to hold a Student's Id of instance of <see cref="StudentDetails"/> 
        /// </summary>
        public string StudentId { get; }       //property

        /// <summary>
        /// FirstName property used to hold a FirstName of instance of <see cref="StudentDetails"/> 
        /// </summary>
        public string StudentName { get; set; }

         /// <summary>
        /// FatherName property used to hold a FatherName of instance of <see cref="StudentDetails"/> 
        /// </summary>       
        public String FatherName { get; set; }


        /// <summary>
        /// DOB property used to hold a DateOfBirth of instance of <see cref="StudentDetails"/> 
        /// </summary>       
        public DateTime DOB { get; set; }



        /// <summary>
        /// Gender property used to hold a Gender of instance of <see cref="StudentDetails"/> 
        /// </summary> 
        public Gender Gender{get; set;}

        /// <summary>
        /// Physics property used to hold a PhysicsMark of instance of <see cref="StudentDetails"/> 
        /// </summary>
        /// <value>0 to 100</value>
        public float Physics { get; set; }


        /// <summary>
        /// Chemistry property used to hold a ChemistryMark of instance of <see cref="StudentDetails"/> 
        /// </summary>
        /// <value>0 to 100</value>
        public float Chemistry { get; set; }


        /// <summary>
        /// Maths property used to hold a MathsMark of instance of <see cref="StudentDetails"/> 
        /// </summary>
        /// <value>0 to 100</value>
        public float Maths { get; set; }






        /// <summary>
        /// Constructor StudentDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="name">name parameter used to assign its value to associated property</param>
        /// <param name="fatherName">fathername parameter used to assign its value to associated property</param>
        /// <param name="dob">dob parameter used to assign its value to associated property</param>
        /// <param name="gender">gender parameter used to assign its value to associated property</param>
        /// <param name="physics">physics parameter used to assign its value to associated property</param>
        /// <param name="chemistry">chemistry parameter used to assign its value to associated property</param>
        /// <param name="maths">maths parameter used to assign its value to associated property</param> <summary>
        public StudentDetails(string name, string fatherName, DateTime dob, Gender gender, int physics, int chemistry, int maths){

            s_studentId++;
            StudentId = "SF"+s_studentId;


            StudentName = name;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }




        /// <summary>
        /// Method CheckEligibility used to check whether the instance of <see cref="StudentDetails" />
        /// </summary>
        /// <param name="cutoff">CutOff limit to check eligiblity</param>
        /// <returns>Returns true if eligible, else false</returns>
        public bool CheckEligibility(double cutoff){
            double average =(double)(Physics + Chemistry + Maths)/3;

            if(average>=cutoff){
                return true;
            }
            else{
                return false;
            }
        }




        /// <summary>
        /// DisplayStudentDetails used to check whether the instance of <see cref="StudentDetails" />
        /// </summary>
        public void  DisplayStudentDetails(){
            System.Console.WriteLine("...........Student Details.........");
            System.Console.WriteLine("Student ID: "+StudentId);
            System.Console.WriteLine("Student Name: "+StudentName);
            System.Console.WriteLine("Student Father Name: "+FatherName);
            System.Console.WriteLine("Student Gender: "+Gender);
            System.Console.WriteLine("Student Physics Mark: "+Physics);
            System.Console.WriteLine("Student Chemistry Mark: "+Chemistry);
            System.Console.WriteLine("Student Maths Mark: "+Maths);
        }

    }
}