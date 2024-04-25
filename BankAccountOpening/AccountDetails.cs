using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public enum Gender{
        male,
        female

    }

    /// <summary>
    /// This class used to perform account details
    /// </summary>
    public class AccountDetails
    {

        private static int s_customerId = 1000;     //field
        public string CustomerId { get; }   //property
        public string CustomerName { get; set; }
        public double Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string EmailId { get; set; }
        public DateTime DOB { get; set; }

        //Gender Gender;
    
        public AccountDetails(string customerName,double balance,Gender gender,long phoneNumber,string emailId,DateTime dob)
        {
            
            s_customerId++;
            CustomerId = "HDFC"+s_customerId;


            CustomerName = customerName;
            Balance = balance;
            Gender = gender;
            Phone = phoneNumber;
            EmailId  = emailId;
            DOB = dob;
        }

        public void Deposite(double amount){
            Balance=Balance+amount;
            Display();
        }

        public void Withdraw(double amount){
            if(amount<Balance){
            Balance = Balance - amount;
            Display();
            }
            else{
                Console.WriteLine("Insufficient Balance");
            }

        }

        public void Display(){
            Console.WriteLine("Your balance amount:"+Balance);
        }
    }
}