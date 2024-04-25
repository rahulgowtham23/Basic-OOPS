using System;
using System.Collections.Generic;
namespace CollegeApplication;

class Program{
    public static void Main(string[] args)
    {
        //List<StudentDetails> studentList = new List<StudentDetails>();

        //object creation

        StudentDetails student1 = new StudentDetails();

        System.Console.WriteLine("Enter your name:");
        student1.StudentName = Console.ReadLine();

        System.Console.WriteLine("Enter your FatherName:");
        student1.FatherName = Console.ReadLine();

        System.Console.WriteLine("Enter your mobile number:");
        student1.MobileNumber = long.Parse(Console.ReadLine());


        System.Console.WriteLine($"{student1.StudentName}  {student1.FatherName} {student1.MobileNumber}");
        
    }
}