using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace CollegeAdmission;


class Program
{
    static List<StudentDetails> studentDetailsList = new List<StudentDetails>();  //static list to store a default values 

    static List<DepartmentDetails> departmentDetailsList = new List<DepartmentDetails>();

    static List<AdmissionDetails> admissionDetailsList = new List<AdmissionDetails>();



    public static void Main(string[] args)
    {
        
        studentDetailsList.Add(new StudentDetails("Ravichandran E","Ettapparajan",DateTime.Parse("11/11/1999"),Gender.Male,95,95,95));
        studentDetailsList.Add(new StudentDetails("Baskaran S","Sethurajan",DateTime.Parse("11/11/1999"),Gender.Male,95,95,95));

        departmentDetailsList.Add(new DepartmentDetails("EEE",29));
        departmentDetailsList.Add(new DepartmentDetails("CSE",29));
        departmentDetailsList.Add(new DepartmentDetails("MECH",30));
        departmentDetailsList.Add(new DepartmentDetails("ECE",30));


        admissionDetailsList.Add(new AdmissionDetails("SF3001","DID101",DateTime.Parse("11/05/2022"),Status.Admitted));
        admissionDetailsList.Add(new AdmissionDetails("SF3002","DID102",DateTime.Parse("12/05/2022"),Status.Admitted));
        
        bool Option = true;

        do{
        System.Console.WriteLine("......................College Admission...................");
        System.Console.WriteLine("Main Menu \n1.Student Registration \n2.Student Login \n3.Department wise seat availability \n4.Exit");
        System.Console.WriteLine("...................................");
        System.Console.Write("Enter your Option: ");
        int userChoice = int.Parse(Console.ReadLine());

        switch(userChoice){
            case 1:
            // Studen registration
            System.Console.Write("Enter your Name: ");
            string studentName = Console.ReadLine();

            System.Console.Write("Enter your Father Name: ");
            string fatherName = Console.ReadLine();

            System.Console.Write("Enter you DOB: dd/MM/yyyy");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            System.Console.Write("Enter Gender Male, Female, Transgender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

            System.Console.Write("Enter physics mark: ");
            int physicsMark = int.Parse(Console.ReadLine());

            System.Console.Write("Enter chemistry mark: ");
            int chemistryMark = int.Parse(Console.ReadLine());

            System.Console.Write("Enter maths mark: ");
            int mathsMark = int.Parse(Console.ReadLine());



            StudentDetails students = new StudentDetails(studentName,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
            studentDetailsList.Add(students);

            System.Console.WriteLine("....................................................................");
            System.Console.WriteLine("Student registered successfully and StudentId is "+students.StudentId);

            // foreach (StudentDetails details in studentDetailsList)
            // {
            //     System.Console.WriteLine("Student ID: "+details.StudentId+"\n Student Name: "+details.StudentName+"\n Father Name: "+details.FatherName+
            //     "DOB: "+details.DOB+"\n Gender: "+details.Gender+"\n physics mark: "+details.Physics+" \n chemistry mark: "+details.Chemistry+"\n maths mark: "+details.Maths);
            // }


            break;

            case 2: 
            // Student Login

            System.Console.Write("Enter the student ID: ");
            string loginId = Console.ReadLine().ToUpper();
            bool flag = true;

            StudentDetails userId = null;       //tO STORE THE CURRENT STUUDENT DETAILS 

            foreach (StudentDetails details in studentDetailsList)
            {
                if(loginId==details.StudentId){
                    flag = false;

                    System.Console.WriteLine("Valid Student ID");

                    userId = details;       //to store the current details of students in userId

                    string choice = "yes".ToLower();
                    do{
                    System.Console.WriteLine("............................................");
                    System.Console.WriteLine("Select an option \na.Check Eligibility \nb.Show Details \nc.Take Admission \nd.Cancel Admission \ne.Show Admission Details \nf.Exit");
                    System.Console.WriteLine("...........................................");
                    char op = char.Parse(Console.ReadLine());

                    switch(op){
                        case 'a':
                        // Check Eligibility
                        double cut = 75.0;
                        if(userId.CheckEligibility(cut)){
                            System.Console.WriteLine("Student is Eligible");
                        }
                        else{
                            System.Console.WriteLine("Student is not Eligible");
                        }

                        
                        break;

                        case 'b':
                        // Display students details
                        userId.DisplayStudentDetails();
                        break;

                        case 'c':
                        // Take Admission

                        //Department List show
                        System.Console.WriteLine("DepartmentID\tDepartmentName\tNo of seats available");
                        foreach(DepartmentDetails dept in departmentDetailsList){
                            System.Console.WriteLine(dept.DepartmentId+"\t"+"\t"+dept.DepartmentName+"\t"+"\t"+dept.NoOfSeats);
                        }


                        System.Console.WriteLine("Choose one Department ID: ");
                        string deptId = Console.ReadLine().ToUpper();
                        bool flag2 = true;
                        foreach(DepartmentDetails dept in departmentDetailsList){
                            if(deptId==dept.DepartmentId){  //depart ID valid or not if condition
                                flag2=false;
                                System.Console.WriteLine("Valid Department ID");
                                double cutoff = 75.0;
                                if(userId.CheckEligibility(cutoff)){    //Eligible or not if condition
                                    System.Console.WriteLine("Eligible to  take admission");
                                    if(dept.NoOfSeats>0){   //seats available or not if condition
                                        bool flag3 = true;
                                        foreach(AdmissionDetails adm in admissionDetailsList){
                                            if(adm.StudentId==userId.StudentId && adm.AdmissionStatus==Status.Admitted){
                                                flag3=false;
                                                System.Console.WriteLine("you are already admitted");
                                            }
                                        }
                                        if(flag3){
                                            //didn't took any admission
                                            System.Console.WriteLine("Not admitted");              //Current student id is stored in userId and current department id is stored in deptID
                                            AdmissionDetails newAdmission = new AdmissionDetails(userId.StudentId,deptId,DateTime.Now,Status.Admitted);
                                            admissionDetailsList.Add(newAdmission);
                                            foreach (DepartmentDetails dep in departmentDetailsList)
                                            {
                                              if(deptId==dep.DepartmentId){
                                                dep.NoOfSeats--;
                                              }
                                            }
                                            System.Console.WriteLine("After updating...");
                                            System.Console.WriteLine("DepartmentID\tDepartmentName\tNo of seats available");
                                            System.Console.WriteLine(dept.DepartmentId+"\t"+"\t"+dept.DepartmentName+"\t"+"\t"+dept.NoOfSeats);
                                            
                                            

                                            // System.Console.WriteLine("After updating...");
                                            // System.Console.WriteLine("AdmissionID\tStudentID\tDepartmentID\tAdmissionDate\tAdmissionStatus");
                                            // foreach(AdmissionDetails ad in admissionDetailsList){
                                            //     System.Console.WriteLine(ad.AdmissionId+"\t"+"\t"+ad.StudentId+"\t"+"\t"+ad.DepartmentId+"\t"+"\t"+ad.AdmissionDate+"\t"+"\t"+ad.AdmissionStatus);
                                            // }
                                            System.Console.WriteLine("..............................................................................");
                                            System.Console.WriteLine("Admission Took successfully and your admission ID is "+newAdmission.AdmissionId);
                                            System.Console.WriteLine("..............................................................................");
                                        }
                                    }
                                    else{   //seats available or not else condition
                                        System.Console.WriteLine("Seats not available");
                                    }
                                }
                                else{   //Eligible or not if condition
                                    System.Console.WriteLine("Not eligible to take admission");
                                }


                            }
                        }
                        if(flag2){  //depart ID valid or not else condition
                            System.Console.WriteLine("Invalid Department ID");
                        }
                        

                        System.Console.WriteLine("Admission Details List after new admission");
                        System.Console.WriteLine("AdmissionID\tStudentID\tDepartmentID\tAdmissionDate\t\t\tAdmissionStatus");
                        
                        foreach (AdmissionDetails admidet in admissionDetailsList)
                        {
                            System.Console.WriteLine(admidet.AdmissionId+"\t"+"\t"+admidet.StudentId+"\t"+"\t"+admidet.DepartmentId+"\t"+"\t"+admidet.AdmissionDate+"\t"+"\t"+admidet.AdmissionStatus);
                        }

                        break;

                        case 'd':
                        // Cancel Admission

                        string tempDepartID = " ";
                        foreach (AdmissionDetails Ad in admissionDetailsList)
                        {
                            if(userId.StudentId==Ad.StudentId){
                                tempDepartID = Ad.DepartmentId;
                                Ad.AdmissionStatus = Status.Cancelled;
                            }
                        }
                        foreach(DepartmentDetails dp in departmentDetailsList){
                            if(dp.DepartmentId==tempDepartID){
                                dp.NoOfSeats++;
                            }
                        }
                        System.Console.WriteLine(".................................");
                        System.Console.WriteLine("Admission Cancelled Successfully!");
                        System.Console.WriteLine(".................................");


                        System.Console.WriteLine("Admission Details List After cancelling...");
                        System.Console.WriteLine("AdmissionID\tStudentID\tDepartmentID\tAdmissionDate\t\t\tAdmissionStatus");
                        foreach (AdmissionDetails admidet in admissionDetailsList)
                        {
                            System.Console.WriteLine(admidet.AdmissionId+"\t"+"\t"+admidet.StudentId+"\t"+"\t"+admidet.DepartmentId+"\t"+"\t"+admidet.AdmissionDate+"\t"+"\t"+admidet.AdmissionStatus);
                        }


                        System.Console.WriteLine("Department Details After Cancelling...");
                        System.Console.WriteLine("DepartmentID\tDepartmentName\tNo of seats available");
                        foreach(DepartmentDetails dp in departmentDetailsList){
                            System.Console.WriteLine(dp.DepartmentId+"\t"+"\t"+dp.DepartmentName+"\t"+"\t"+dp.NoOfSeats);
                        }

                        break;

                        case 'e':
                        // Show Admission Details of current student
                        System.Console.WriteLine("Admission Details of current logged student");
                        System.Console.WriteLine("AdmissionID\tStudentID\tDepartmentID\tAdmissionDate\t\t\tAdmissionStatus");
                        foreach (AdmissionDetails admidet in admissionDetailsList)
                        {
                            if(userId.StudentId==admidet.StudentId){
                                System.Console.WriteLine(admidet.AdmissionId+"\t"+"\t"+admidet.StudentId+"\t"+"\t"+admidet.DepartmentId+"\t"+"\t"+admidet.AdmissionDate+"\t"+"\t"+admidet.AdmissionStatus);
                            }
                            
                        }

                        break;

                        case 'f':
                        // Exit from the submenu
                        choice = "no".ToLower();
                        break;

                        default:
                        System.Console.WriteLine("Invalid Option");
                        break;



                    }                        
                    }while(choice=="yes");

                }
            }
            if(flag){
                System.Console.WriteLine("Invalid Student ID");
            }

            break;

            case 3:
            // Department wise availability
            System.Console.WriteLine("DepartmentID\tDepartmentName\tNo of seats available");
            foreach(DepartmentDetails dp in departmentDetailsList){
                System.Console.WriteLine(dp.DepartmentId+"\t"+"\t"+dp.DepartmentName+"\t"+"\t"+dp.NoOfSeats);
            }

            break;

            case 4:
            // Exit from the main menu
            System.Console.WriteLine("Exiting from application......");
            Option = false;
            break;


            default:
            System.Console.WriteLine("Invalid Option");
            break;

        }
        }while(Option);

    }
}