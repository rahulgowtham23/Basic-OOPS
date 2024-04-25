using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculation
{
    public class EbBillDetails
    {

        private static int s_meterId = 1000;         //field always camel case and private it should be static preffix s should be added

        public String MeterId { get; set; }     // property should be pascal case


        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string MailId { get; set; }
        // public double UnitsUsed { get; set; }


        public EbBillDetails(string name,long phoneNumber,string mailId){

            s_meterId++;

            MeterId = "EB"+s_meterId;
            UserName = name;
            PhoneNumber = phoneNumber;
            MailId = mailId;
        }



        public void CalculateAmountAndBill(double unitsUsed){
            System.Console.WriteLine("...........EB BILL............");
            System.Console.WriteLine("Meter ID is: "+MeterId);
            System.Console.WriteLine("User Name: "+UserName);
            System.Console.WriteLine("Units used: "+unitsUsed);
            System.Console.WriteLine("Amount is: "+unitsUsed*5);
            System.Console.WriteLine("..............................");
        }




        public void DisplayUserDetails(){
            System.Console.WriteLine(".......USer Details.......");
            System.Console.WriteLine("Meter ID is: "+MeterId);
            System.Console.WriteLine("User Name: "+UserName);
            System.Console.WriteLine("User Phone number: "+PhoneNumber);
            System.Console.WriteLine("User MailID: "+MailId);
            System.Console.WriteLine("...........................");
        }
    }
}