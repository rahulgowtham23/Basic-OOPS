using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{

    public enum WorkLocation{
        chennai,
        banglore,
        coimbatore,
        madurai

    }

    public enum Gender{
        male,
        female
    }


    public class EmployeeDetails
    {

        private static int s_employeeId = 1000; //field

        public string EmployeeId{get;}  //property

        public string EmployeeName { get; set; }    

        public Gender Gender { get; set; }

        public string Role { get; set; }

        public WorkLocation WorkLocation { get; set; }

        public string TeamName { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int NumberOfWorkingDaysInMonth { get; set; }     

        public int NumberOfLeaveTaken { get; set; }



        public EmployeeDetails(string name,Gender gender, string role, WorkLocation location,string team,DateTime joining,int workingDays,int leaveTaken){

            s_employeeId++;
            EmployeeId = "SF"+s_employeeId;

            EmployeeName = name;
            Gender = gender;
            Role = role;
            WorkLocation = location;
            TeamName = team;
            DateOfJoining = joining;
            NumberOfWorkingDaysInMonth = workingDays;
            NumberOfLeaveTaken = leaveTaken;

        }


        public void CalculateSalary(){
            System.Console.WriteLine("Your salary is: "+(NumberOfWorkingDaysInMonth-NumberOfLeaveTaken)*500);
        }

        public void DisplayDetails(){
            System.Console.WriteLine("Employee ID: "+EmployeeId);
            System.Console.WriteLine("Employee Name: "+EmployeeName);
            System.Console.WriteLine("Employee Gender: "+Gender);
            System.Console.WriteLine("Employee Role: "+Role);
            System.Console.WriteLine("Employee WorkLocation: "+WorkLocation);
            System.Console.WriteLine("Employee TeamName: "+TeamName);
            System.Console.WriteLine("Employee Date Of Joinig: "+DateOfJoining.ToString("dd/MM/yyyy"));
            System.Console.WriteLine("Employee Number of working days in month: "+NumberOfWorkingDaysInMonth);
            System.Console.WriteLine("Employee Number number of leave taken: "+NumberOfLeaveTaken);
        }
    }
}