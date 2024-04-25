using System;
using System.Collections.Generic;

namespace EbBillCalculation;


class Program
{
    public static void Main(string[] args)
    {
        List<EbBillDetails> userDetailList = new List<EbBillDetails>();

        bool option = true;
        
        do{
        Console.WriteLine(".............EB BILL CALCULATION............");
        Console.WriteLine("Main Menu \n1.Registartion \n2.Login \n3.Exit");
        int userChoice = int.Parse(Console.ReadLine());

        switch(userChoice){
            case 1:
            System.Console.WriteLine("Enter your Name:");
            string userName = Console.ReadLine();

            System.Console.WriteLine("Enter your Phone Number:");
            long phoneNumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your MailId:");
            string mailId = Console.ReadLine();

            // System.Console.WriteLine("No.of.Units used:");
            // double unitsUsed = double.Parse(Console.ReadLine());


            EbBillDetails user = new EbBillDetails(userName,phoneNumber,mailId);
            userDetailList.Add(user);

            Console.WriteLine("You have registered successfully!!!. your Meter ID is: "+user.MeterId);
            break;



            case 2:

            System.Console.WriteLine("Enter your Meter ID:");
            string meterId = Console.ReadLine().ToUpper();
            bool flag = true;
            EbBillDetails userDetails = null;
            foreach (EbBillDetails details in userDetailList)
            {
                if(meterId == details.MeterId){
                    flag = false;
                    userDetails = details;
                    string choice="yes";
                    do{
                    System.Console.WriteLine("Enter the option 1.Calculate Amount 2.Display user Details 3.Exit");
                    System.Console.WriteLine("........................................................................");
                    int op = int.Parse(Console.ReadLine());
                    
                    switch(op){
                        case 1:
                        System.Console.WriteLine("No.of.Units used:");
                        double unitsUsed = double.Parse(Console.ReadLine());
                        // System.Console.WriteLine("Meter ID: "+userDetails.MeterId +"\n User Name: "+userDetails.UserName+ "\n Units Used: "+unitsUsed);
                        userDetails.CalculateAmountAndBill(unitsUsed);

                                               
                        break;

                        case 2:
                        userDetails.DisplayUserDetails();
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
                System.Console.WriteLine("Invalid Meter ID");
            }



            break;

            case 3:
            Console.WriteLine("Exiting from application.....");            
            option = false;
            break;

            default:
            Console.WriteLine("Invalid option");
   
            break;
        }
        }while(option);

    }
}