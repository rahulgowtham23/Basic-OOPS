using System;

namespace StudentAdmission; //File scoped namespace

class Program 
{
    public static void Main(string[] args)
    {
        //Default Data Calling
        Operations.AddDefaultData();

        //Calling Main Menu
        Operations.MainMenu();
    }
}