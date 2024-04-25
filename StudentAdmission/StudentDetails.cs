using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender{Select, Male, Female}       //enum is a keyword

    public class StudentDetails
    {
        /*
        a.	StudentID – (AutoGeneration ID – SF3000)
        b.	StudentName
        c.	FatherName
        d.	DOB
        e.	Gender – Enum (Male, Female, Transgender)
        f.	Physics
        g.	Chemistry
        h.	Maths
        */

        //Field
        //Static field
        private static int s_studentID = 3000;
        


        //Properties
        public string StudentID { get;} //Read Only Property
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int PhysicsMark { get; set; }
        public int ChemistryMark { get; set; }
        public int MathsMark { get; set; }



        //Constructor
        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender, int physicsMark, int chemistryMark, int mathsMark)
        {
            //Auto Incrementation
            s_studentID++;

            StudentID = "SF" + s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            PhysicsMark = physicsMark;
            ChemistryMark = chemistryMark;
            MathsMark = mathsMark;
        }

        //Methods to Calculate average
        public double Average()
        {
            int total = PhysicsMark + ChemistryMark + MathsMark;
            double average = (double) total/3;     
            return average;
        }



        //Methods to check eligibility
        public bool CheckEligibility(double cutOff)
        {
            if(Average()>=cutOff)
            {
                return true;
            }
            // else{
            //     return false;
            // }
            return false;
        }

    }
}