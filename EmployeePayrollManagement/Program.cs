using System;
using System.Collections.Generic;


namespace EmployeePayrollManagement;

class Program 
{
    public static void Main(string[] args)
    {
        bool option = true;

        List<EmployeeDetails>employeeDetailsList = new List<EmployeeDetails>();

        do{

        Console.WriteLine("Main Menu \n1.Registration \n2.Login \n3.Exit");
        
        int userChoice = int.Parse(Console.ReadLine());

        switch(userChoice){
            case 1:
            System.Console.WriteLine("Enter your Name:");
            string employeeName = Console.ReadLine();

            System.Console.WriteLine("Enter Gender Male, Female");
            Gender employeeGender = Enum.Parse<Gender>(Console.ReadLine(),true);

            System.Console.WriteLine("Enter your Role:");
            string employeeRole = Console.ReadLine();

            System.Console.WriteLine("Enter Work Location Chennai, Banglore, Madurai, Coimbatore");
            WorkLocation employeeWorkLocation = Enum.Parse<WorkLocation>(Console.ReadLine(),true);


            System.Console.WriteLine("Enter your Team Name");
            string employeeTeam = Console.ReadLine();


            System.Console.WriteLine("Enter your Date of Joining");
            DateTime employeeDateOfJoining = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            System.Console.WriteLine("Enter your number of working days in a month:");
            int employeeNumberOfWorkingDaysInMonth = int.Parse(Console.ReadLine());


            System.Console.WriteLine("Enter number of leave taken:"); 
            int employeeLeaveTaken = int.Parse(Console.ReadLine());


            EmployeeDetails employee = new EmployeeDetails(employeeName,employeeGender,employeeRole,employeeWorkLocation,employeeTeam,employeeDateOfJoining,
            employeeNumberOfWorkingDaysInMonth,employeeLeaveTaken);

            employeeDetailsList.Add(employee);

            System.Console.WriteLine("You have registered successfully! your Employee ID is "+employee.EmployeeId);
            break;



            case 2:
            System.Console.WriteLine("Enter your Employee ID");
            string loginId = Console.ReadLine().ToUpper();
            bool flag = true;

            EmployeeDetails userid = null;
            foreach (EmployeeDetails details in employeeDetailsList)
            {
                if(loginId==details.EmployeeId){
                    flag = false;
                    userid = details;

                    string choice = "yes";
                    do{
                    Console.WriteLine("Enter option 1.Calculate salary 2.Display details 3.Exit");
                    int op = int.Parse(Console.ReadLine());

                    switch(op){
                        case 1:
                        userid.CalculateSalary();
                        break;

                        case 2:
                        userid.DisplayDetails();
                        break;

                        case 3:
                        choice="no";
                        break;

                        default:
                        System.Console.WriteLine("Invalid option");
                        break;
                    }


                    }while(choice=="yes");

                }
            }
            if(flag){
                System.Console.WriteLine("Invalid user");
            }

            break;

            case 3:
            Console.WriteLine("Exiting from application....");
            option = false;
            break;

            default:
            Console.WriteLine("Invalid option");
            break;

        }
        }while(option);


    }
}