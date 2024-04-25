using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BankAccountOpening;

public

class Program
{
    public static void Main(string[] args)
    {

        bool option = true;
        // string option="yes";
        List<AccountDetails>accountDetailsList = new List<AccountDetails>();

        do
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1.Registartion");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");

            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    //AccountDetails customer = new AccountDetails();
                    

                    Console.WriteLine("Enter your Name:");
                    string customerName = Console.ReadLine();
                    //customer.CustomerName=Console.ReadLine();
                    //System.Console.WriteLine(customer.CustomerName);

                    Console.WriteLine("Enter your deposit money:");
                    double balance = double.Parse(Console.ReadLine());
                    //customer.Balance=long.Parse(Console.ReadLine());
                    //System.Console.WriteLine(customer.Balance);

                    Console.WriteLine("Enter your Gender Male, Female:");
                    //string gender = Console.ReadLine();
                    Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
                    //customer.Gender=Console.ReadLine();
                    //System.Console.WriteLine(customer.Gender);


                    Console.WriteLine("Enter Phone Number:");
                    long phoneNumber = long.Parse(Console.ReadLine());
                    //customer.Phone = long.Parse(Console.ReadLine());
                    //System.Console.WriteLine(customer.Phone);

                    Console.WriteLine("Enter MailId:");
                    string emailId = Console.ReadLine();
                    //customer.EmailId = Console.ReadLine();
                    //System.Console.WriteLine(customer.EmailId);


                    Console.WriteLine("Enter DOB:");
                    DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    //customer.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    //System.Console.WriteLine(customer.DOB.ToString("dd/MM/yyyy"));

                    AccountDetails customer = new AccountDetails(customerName,balance,gender,phoneNumber,emailId,dob);
                    accountDetailsList.Add(customer);


                    // foreach (AccountDetails details in accountDetailsList)
                    // {
                    //     Console.WriteLine("CustomerID:"+ details.CustomerId + "\n CustomerName:" + details.CustomerName + "\n Balance:"+details.Balance + 
                    //     "\n Gender:" + details.Gender + "\n PhoneNumber:" + details.Phone + "\n MailId:" + details.EmailId + "\n DOB:" + details.DOB.ToString("dd/MM/yyyy"));
                    // }

                    //customer.customerID = 10; using field access change it to private
                    ///customer.CustomerId="100"; using property access remove set

                    Console.WriteLine("You have Registered successfully !. Your ID is " + customer.CustomerId);
                    //option = false;
                    break;


                case 2:
                    Console.WriteLine("Enter Customer ID");
                    string loginId = Console.ReadLine().ToUpper();


                    bool flag=true; // for loginID loop break
                    AccountDetails userid = null;
                    
                    foreach (AccountDetails details in accountDetailsList)
                    {
                        if(loginId==details.CustomerId){
                            flag=false;
                            userid = details;
                            string choice = "yes";
                            do{
                                Console.WriteLine("Enter the option 1.Depoosit 2.Withdraw 3.Balance check 4.Exit");
                                int op = int.Parse(Console.ReadLine());
                                switch(op){
                                    case 1:
                                    System.Console.WriteLine("Enter your deposit money:");
                                    double deposit = double.Parse(Console.ReadLine());
                                    userid.Deposite(deposit);
                                    break;

                                    case 2:
                                    System.Console.WriteLine("Enter your withdraw money:");
                                    double withdraw = double.Parse(Console.ReadLine());
                                    userid.Withdraw(withdraw);
                                    break;

                                    case 3:
                                    userid.Display();
                                    break;

                                    case 4:
                                    choice="no";
                                    break;

                                    default:
                                    System.Console.WriteLine("Invalid input");
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
                    Console.WriteLine("Exiting application");
                    option = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            // Console.WriteLine("Do you want to continue? type (yes/no)");
            // string again = Console.ReadLine();
            // if(again=="yes")
            //     option = true;


        } while (option);






    }
}