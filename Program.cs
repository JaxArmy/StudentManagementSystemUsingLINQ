//Scripted by Jaxson Christie on 4/18/2024
//COP2551.0M1

//The Student Management System Application will take Users information of students ID, first and last name, and age to organize their data; and allow user to retrieve it using LINQ.

//TAKEAWAYS:
//       1) Take my some methods inside "StudentManager" and create another class just for printing and just for listing, etc for organziation purposes.
//       2)  Get Github to save my copies of my code to allow me to go back and forth - if needed on old working code. 

using System;
using System.Runtime.CompilerServices;

namespace StudentManagementSystemUsingLINQ
{
    class Program
    {
        public bool mainMenu(StudentManager studentManager)
        {

            //array holding options
            string[] mmSelections = ["Add A New Student\n", "Retrieve All Students\n", "Retrieve Students via First Name\n", "Retrieve Students via Last Name\n", "Retrieve Students via Age\n", "Exit the Application\n"];
            int[] mmPlaceHolders = [1, 2, 3, 4, 5, 6, 7];

            Console.WriteLine("\n*************************\n" +
           "*       Main Menu       " +
           "*" + "\n*************************\n");

            Console.WriteLine("Please type the Number for one of the displayed paths: \n");

            //print all options
            for (int i = 0; i < mmSelections.Length; i++)
            {
                Console.WriteLine("{1}) {0}", mmSelections[i], mmPlaceHolders[i]);
            }

            //takes user to selected submenu
            Console.Write("Your Input: ");

            switch (Console.ReadLine())
            {
                case "1":
                    studentManager.addNewStudent();
                    return true;
                case "2":
                    studentManager.listStudentData();
                    return true;
                case "3":
                    studentManager.retrieve_StuFirstName();
                    return true;
                case "4":
                    studentManager.retrieve_StuLastName();
                    return true;
                case "5":
                    studentManager.retrieve_StuAge();
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        }

        static void Main(string[] args)
        {
            bool displayMainMenu = true;

            StudentManager studentManager = new StudentManager();

            Program program = new Program();

            while (displayMainMenu)
            {
                // stores return value in bool 
                bool isWhat = program.mainMenu(studentManager);

                // checks whether user wants to exit or stay
                if (isWhat == false)
                {
                    Console.WriteLine("\nThank You For Using This Application!\n");
                    break;
                }
            }
        }
    }
}
