using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Static Class
    public static class Operations
    {

        //Local/Global Object Creation
        static StudentDetails currentLoggedInStudent;

        //Static list creation
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> depatmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main Menu Method
        public static void MainMenu()
        {
            System.Console.WriteLine("**************Welcome to Syncfusion College of Engineering and Technology******************");

            string mainChoice = "yes";  //condition for do while loop
            do
            {
                //Need to show main menu option
                System.Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Departmentwise Seat Availability\n4. Exit");
                //Need to get an input from user and validate.
                System.Console.Write("Enter your option: ");
                int mainOption = int.Parse(Console.ReadLine());     //Need to validate using try parse

                //Need to create mainmenu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("***************Student Registration*******************");
                            StudentRegistration();
                            break;
                        }

                    case 2:
                        {
                            System.Console.WriteLine("*********************Student Login***********************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("***********Departmentwise Seat Availability****************");
                            DepartmentwiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("***************Application Exited Successfully********************");
                            mainChoice = "no";
                            break;
                        }

                }//Need to iterate until the option is exit

            } while (mainChoice == "yes");

        }//Main Menu ends



        //Student Registration - Method
        public static void StudentRegistration()
        {
            //Need to get required details
            System.Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            System.Console.Write("Enter your FatherName: ");
            string fatherName = Console.ReadLine();
            System.Console.Write("Enter your DOB as specified DD/MM/YYYY: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            System.Console.Write("Enter your Gender Male, Female: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.Write("Enter your Physics Mark: ");
            int physicsMark = int.Parse(Console.ReadLine());
            System.Console.Write("Enter your Chemistry Mark: ");
            int chemistryMark = int.Parse(Console.ReadLine());
            System.Console.Write("Enter your Maths Mark: ");
            int mathsMark = int.Parse(Console.ReadLine());

            //Need to create an object
            StudentDetails student = new StudentDetails(name, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);

            //Need to add it in the list
            studentList.Add(student);

            //Need to display confirmation message and ID
            System.Console.WriteLine($"Registration successful.Student ID: {student.StudentID}");

        }//Student Registration Method Ends



        //Student Login - Method
        public static void StudentLogin()
        {
            //Need to get ID input
            System.Console.Write("Enter your Student ID: ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate by its presence in the list
            bool flag = true;
            foreach (StudentDetails student in studentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    flag = false;
                    //Current user assign to global variable
                    currentLoggedInStudent = student;
                    System.Console.WriteLine("Logged in Successfully.....");
                    //Need to call submenu
                    SubMenu();
                    break;
                }
            }
            //If not - Invalid ID
            if (flag)
            {
                System.Console.WriteLine("Invalid Student ID or ID is not Present");
            }
        }//student login method ends



        //Submenu method
        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("************SubMenu***************");
                //Need to show submenu options
                System.Console.WriteLine("Select an option\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Details\n6. Exit");

                //getting user option
                System.Console.Write("Enter your option: ");
                int subOption = int.Parse(Console.ReadLine());
                //Need to create a submenu structure
                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("************Check eligibility**************");
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("*****************Show details*********************");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("****************Take admission*********************");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("***************Cancel admission********************");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("***************Show admission details***************");
                            AdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("**************Taking back to main menu*************");
                            subChoice = "no";
                            break;
                        }
                }
                //iterate till option is exit

            } while (subChoice == "yes");
        }//Submenu methods ends



        //Check eligibility method
        public static void CheckEligibility()
        {
            //Get the cutoff value as input
            System.Console.Write("Enter the CutOff Value: ");
            double cutOff = double.Parse(Console.ReadLine());

            //Check  eligible or not
            if (currentLoggedInStudent.CheckEligibility(cutOff))
            {
                System.Console.WriteLine("Student is eligible");
            }
            else
            {
                System.Console.WriteLine("Student is not eligible");
            }
        }//Check eligibility method ends


        //Show Details method
        public static void ShowDetails()
        {
            //Need to show current student's detail
            // foreach (StudentDetails student in studentList)
            // {
            //     if(currentLoggedInStudent.StudentID.Equals(student.StudentID))
            //     {
            //          System.Console.WriteLine($"|{student.StudentID}|{student.StudentName}|{student.FatherName}|{student.DOB}|{student.Gender}|{student.PhysicsMark}|{student.ChemistryMark}|{student.MathsMark}");
            //      }
            // }
            //    
            // System.Console.WriteLine();

            System.Console.WriteLine($"|Student ID|Student Name|Father Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark");
            System.Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}");

        }//Show Details method ends 


        //Take admission method
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentwiseSeatAvailability();
            //Ask department ID from user
            System.Console.WriteLine("Select an Department ID: ");
            string departmentID = Console.ReadLine().ToUpper();
            //check the ID present or not
            bool flag = true;
            foreach (DepartmentDetails department in depatmentList)
            {
                if (departmentID.Equals(department.DepartmentID))
                {
                    flag = false;
                    //If present check the student is eligible or not
                    if (currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check the seat availability
                        if(department.NumberOfSeats>0)
                        {
                        //Check student already taken any admission
                        int count = 0;
                        foreach (AdmissionDetails admission in admissionList)
                        {
                            if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                            {
                                count++;
                            }
                        }
                        if(count==0)
                        {
                        //Create admission object
                        AdmissionDetails admissionTaken = new AdmissionDetails(currentLoggedInStudent.StudentID,departmentID,DateTime.Now,AdmissionStatus.Admitted); 
                        //Reduce seat count
                        department.NumberOfSeats--;
                        //Add to the admission list
                        admissionList.Add(admissionTaken);
                        //Display Admission successful message
                        System.Console.WriteLine($"You have taken Admission successfully. Admission ID: {admissionTaken.AdmissionID}");
                        }
                        else
                        {
                            System.Console.WriteLine("You have already taken an admission");
                        }

                        }
                        else
                        {
                            System.Console.WriteLine("Seats not available");
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("You are not eligible due to low cutoff");
                    }

                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid Department ID or Deparment ID not present");
            }

        }//Take admission method ends


        //Cancel admission method
        public static void CancelAdmission()
        {
            bool flag = true;
            //Check student taken any admission and display it
            foreach (AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    //Cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach (DepartmentDetails department in depatmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                        }
                        break;
                    }

                    break;
                }
                if(flag)
                {
                    System.Console.WriteLine("You have not admission to cancel");
                }

            }

        }//Cancel admission method ends



        //Admission details method
        public static void AdmissionDetails()
        {
            //Need to show current logged in student's admission details
            System.Console.WriteLine($"|Admission ID|Student ID|Department ID|Admission Date|Admission Status|");
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    System.Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
                }
            }
            System.Console.WriteLine();
        }//admission details method ends







        //Departmentwise seat availability method
        public static void DepartmentwiseSeatAvailability()
        {
            string line = "______________________________________________________";
            //Need to show all department wise seat availability
            System.Console.WriteLine(line);
            //System.Console.WriteLine("|DepartmentID|DepartmentName|NumberOfSeats|");
            System.Console.WriteLine($"|{"DepartmentID",-20}|{"DepartmentName",-20}|{"NumberOfSeats",-20}|");
            System.Console.WriteLine(line);
            foreach (DepartmentDetails department in depatmentList)
            {
                System.Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartmentName,-14}|{department.NumberOfSeats,-13}|");
                System.Console.WriteLine(line);
            }
            System.Console.WriteLine();

        }//Departmentwise seat availability method ends




        //Adding Default Data to Lists - Method
        public static void AddDefaultData()
        {
            //Adding Default Data to StudentDetailsList

            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            // studentList.Add(student1);   
            // studentList.Add(student2);
            studentList.AddRange(new List<StudentDetails>() { student1, student2 });


            //Adding Default Data to DepartmentList

            DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
            depatmentList.AddRange(new List<DepartmentDetails>() { department1, department2, department3, department4 });


            //Adding Default Data to AdmissionList

            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, department1.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID, department2.DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>() { admission1, admission2 });


        }//Default data ends




    }
}