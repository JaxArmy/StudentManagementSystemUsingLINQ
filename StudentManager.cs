using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemUsingLINQ
{
    class StudentManager
    {
        private List<Student> studentList = new List<Student>();

        Student student = new Student(0, "", "", 0);

        public StudentManager()
        {
            studentList.Add(new Student(57324, "Sarah", "Ivson", 17));
            studentList.Add(new Student(76525, "Ky", "Ulison", 15));
            studentList.Add(new Student(85469, "Mark", "Terri", 15));
            studentList.Add(new Student(67645, "Jason", "Hoying", 18));
            studentList.Add(new Student(77645, "Joe", "Gunning", 17));
            studentList.Add(new Student(67645, "Jill", "Ostu", 18));
            studentList.Add(new Student(68945, "Bill", "Missle", 19));
        }

        //Method displays to user what is inside the list.
        public void listStudentData()
        {

            Console.WriteLine("\n**************************************************\n" +
                "*       List of Students in the Database.        " +
                "*" + "\n**************************************************\n");

            int[] newTaskPlaceHolders = Enumerable.Range(1, 1000).ToArray();

            //print all options
            Console.WriteLine("  |  ID|" + "F.Name" + "|L.Name|" + " Age |");
            for (int i = 0; i < studentList.Count; i++)
            {
                Console.WriteLine("{0}) {1}", newTaskPlaceHolders[i], studentList[i]);
                ToString();
            }

            Console.WriteLine("\n\nPlease Enter Any Key to Continue");
            Console.ReadKey();
        }

        public void addNewStudent()
        {

            //Method Variables
            bool isChecked = true;
            bool isValid = false;
            int a = 3;
            int stuID;
            int age = 0;

            Console.WriteLine("\n   *******************************************\n" +
                "   *       Please Enter A New Student.       " + "*" +
                "\n   *******************************************");

            while (isChecked == true)
            {
                listStudentData();

                try
                {
                    //Stores Users input and Trim ensures User doesnt accidently input spaces to damage the case sensitivity 
                    Console.WriteLine("5-Digit Student ID: ");
                    stuID = int.Parse(Console.ReadLine().Trim());
                    bool HasFound = false;

                    isChecked = checksStudentIdDigitLength(stuID, isChecked);

                    

                    //stops from allowing printing "added student" WriteLine
                    if ( isChecked == false)
                    {
                        a = 0;
                    }
                    else
                    {
                        a = 3;
                    }

                    foreach (var list in studentList)
                    {
                        HasFound = stuID.Equals(list.StudentId); //compares user input w/ list

                        //if match found anywhere in list, will break out of loop
                        if (HasFound == true)
                        {
                            Console.WriteLine("\n<Student with this ID already exits: Please enter a different student ID.>\n");
                            isChecked = false;
                            a = 0;
                        }
                    }

                    if (isChecked == true)
                    {
                        Console.WriteLine("\nFirst Name: ");
                        string fName = Console.ReadLine().Trim();

                        Console.WriteLine("\nLast Name: ");
                        string lName = Console.ReadLine().Trim();

                        Console.WriteLine("\nAge: ");
                        string strngAge = Console.ReadLine().Trim();

                        isValid = checkAgeDigitLength(strngAge);

                        if (isValid == true)
                        {
                            int.TryParse(strngAge, out age);

                            //adding users input into the list
                            studentList.Add(new Student(stuID, fName, lName, age));
                        }

                        else
                        {
                            Console.WriteLine("\n<Please Enter a 2-Digit Number for the Student Age.>");
                            a = 0;
                        }
                    }
                }

                catch
                {
                    Console.WriteLine("\n<Please Enter a number for your 5-digit ID number or your age.>");
                    a = 1;
                }

                if (a == 3)
                {
                    Console.WriteLine("\nStudent Added! Would You Like To Add Another Student?");
                }

                isChecked = outputRetry();
            }
        }

        public void retrieve_StuFirstName()
        {
            //Method Variables
            bool isChecked = true;
            bool shouldContinue = true;
            string userInput;

            Console.WriteLine("\n***********************************************************\n" +
                "*       Please Enter the First Name of the Student.      " +
                "*" + "\n***********************************************************\n");

            while (isChecked == true)
            {
                //Resets a val for if statements
                int a = 4;

                allStudentsFirstNamesPrint();

                try
                {
                    Console.WriteLine("\nPlease Type the EXACT First Name to retrieve there information.");

                    userInput = Console.ReadLine().Trim();

                    shouldContinue = checkInputFirstName(userInput);

                    if (shouldContinue == true)
                    {
                        Console.WriteLine("\n*************\n");

                        IEnumerable<Student> query = studentList.Select(r => r).Where(a => a.FirstName == userInput);

                        foreach (var fName in query)
                        {
                            Console.WriteLine(fName);
                        }

                        a = 3;
                    }
                    
                    else
                    {
                        Console.WriteLine("\n<Please Enter a Student First Name.>");
                    }
                }

                catch
                {
                    Console.WriteLine("\n<Please Enter the a EXACT First Name of the Student.>");
                    a = 1;
                }

                if (a == 3)
                {
                    Console.WriteLine("\nStudent Found! Would You Like To Find Another Student?");

                }

                isChecked = outputRetry();
            }
        }

        public void retrieve_StudentsAll()
        {
            IEnumerable<Student> query = studentList.Select(r => r);

            foreach (var fruit in query)
            {
                Console.WriteLine(fruit);
            }
        }

        public void retrieve_StuLastName()
        {
            //Method Variables
            bool shouldContinue = true;
            bool IsChecked = true;

            Console.WriteLine("\n***********************************************************\n" +
                "*       Please Enter the Last Name of the Student.      " +
                "*" + "\n***********************************************************");

            while (IsChecked == true)
            {
                //Resets a val for if statements
                int a = 4;

                allStudentsLastNamesPrint();

                try
                {
                    Console.WriteLine("\nPlease Type the EXACT Last Name to retrieve there information.");

                    string userInput = Console.ReadLine().Trim();

                    shouldContinue = checkInputLastName(userInput);

                    if (shouldContinue == true)
                    {
                        Console.WriteLine("\n*************\n");

                        IEnumerable<Student> query = studentList.Select(r => r).Where(a => a.LastName == userInput);

                        foreach (var lNames in query)
                        {
                            Console.WriteLine(lNames);
                        }

                        a = 3;
                    }

                    else
                    {
                        Console.WriteLine("\n<Please Enter a Student Last Name.>");
                    }
                }

                catch
                {
                    Console.WriteLine("\n<Please Enter the a EXACT Last Name of the Student.>");
                    a = 1;
                }

                if (a == 3)
                {
                    Console.WriteLine("\nStudent Found! Would You Like To Find Another Student?");

                }

                IsChecked = outputRetry();
            }
        }

        public void retrieve_StuAge()
        {
            //Method Variables
            bool shouldContinue = true;
            bool isChecked = true;
            int age = 0;

            Console.WriteLine("\n***********************************************************\n" +
                "*       Please Enter the Student Age.      " +
                "*" + "\n***********************************************************");

            while (isChecked == true)
            {
                //Resets a val for if statements
                int a = 4;

                allStudentAgesPrint();

                try
                {
                    Console.WriteLine("\nPlease Type the 2-Digit Age to retrieve there information.");

                    string strnInput = Console.ReadLine().Trim();

                    shouldContinue = checkingInputAge(strnInput);

                    if (shouldContinue == true)
                    {
                        Console.WriteLine("\n*************\n");

                        //Converts string to int
                        int.TryParse(strnInput, out age);

                        IEnumerable<Student> query = studentList.Select(r => r).Where(a => a.Age == age);

                        foreach (var stuAge in query)
                        {
                            Console.WriteLine(stuAge);
                        }

                        a = 3;
                    }

                    else
                    {
                        Console.WriteLine("\n<Please Enter a 2-Digit Student Age.>");
                    }
                }

                catch
                {
                    Console.WriteLine("\n<Please Enter a Student Age.>");
                    a = 1;
                }

                if (a == 3)
                {
                    Console.WriteLine("\nStudent Found! Would You Like To Find Another Student?");

                }

                isChecked = outputRetry();
            }
        }

        public bool outputRetry()
        {
            Console.WriteLine("\nPlease type the Number for one of the displayed paths: \n");

            //array holding options
            string[] newTaskSections = ["Try Again?\n", "Exit to Main Menu\n"];
            int[] newTaskPlaceHolders = [1, 2];

            //print all options
            for (int i = 0; i < newTaskSections.Length; i++)
            {
                Console.WriteLine("{1}) {0}", newTaskSections[i], newTaskPlaceHolders[i]);
            }

            // stores users decision for exiting or new attempt
            Console.Write("Your Input: ");
            string checkingAnswer = Console.ReadLine();

            //checks users decision
            bool HasDecided = true;

            if (checkingAnswer == "1")
            {
                HasDecided = true;
            }

            else if (checkingAnswer == "2")
            {
                HasDecided = false;
            }

            return HasDecided;
        }

        public void allStudentsFirstNamesPrint()
        {
            Console.WriteLine("\n~~Entire List of Student First Names.~~\n");

            IEnumerable<string> studentsFirstNames = studentList.Select(cust => cust.FirstName);

            foreach (string name in studentsFirstNames)
            {
                Console.WriteLine(name);
            }
        }
        public void allStudentsLastNamesPrint()
        {
            Console.WriteLine("\n~~Entire List of Student Last Names.~~\n");

            IEnumerable<string> studentsLastNames = studentList.Select(cust => cust.LastName);

            foreach (string name in studentsLastNames)
            {
                Console.WriteLine(name);
            }
        }

        public void allStudentAgesPrint()
        {
            Console.WriteLine("\n~~Entire List of Student Ages.~~\n");

            IEnumerable<int> studentsLastNames = studentList.Select(cust => cust.Age);

            foreach (int age in studentsLastNames)
            {
                Console.WriteLine(age);
            }
        }

        public bool checksStudentIdDigitLength(int userInput, bool isCheckID)
        {
            int intDigitCounter = 0; //inner while loop int value counter

            bool isTrue = true;

            while (isTrue == true)
            {
                //tells the number of digits in the int value
                while (userInput > 0)
                {
                    intDigitCounter++;
                    userInput = userInput / 10;
                }

                if (intDigitCounter == 5)
                {
                    isCheckID = true;
                    break;
                }

                else if (intDigitCounter < 5)
                {
                    Console.WriteLine("\n<Invalid Input: A Non-Number, Zero, Negative Number, or a Long Number was inputed: Please enter a 5-Digit ID Number.>");
                    isCheckID = false;
                    break;
                }

                else if (intDigitCounter > 5)
                {
                    Console.WriteLine("\n<Invalid Input: A Non-Number, Zero, Negative Number, or a Long Number was inputed: Please enter a 5-Digit ID Number.>");
                    isCheckID = false;
                    break;
                }
            }

            return isCheckID;
        }

        public bool checkInputFirstName(string userInput)
        {
            bool isChecked;
            bool doesExist = false;

            foreach (var list in studentList)
            {
                isChecked = userInput.Equals(list.FirstName); //compares user input w/ list

                //if match found anywhere in list, will break out of loop
                if (isChecked == true)
                {
                    doesExist = true;
                    break;
                }
            }

            return doesExist;
        }

        public bool checkInputLastName(string userInput)
        {
            bool isChecked;
            bool doesExist = false;

            foreach (var list in studentList)
            {
                isChecked = userInput.Equals(list.LastName); //compares user input w/ list

                //if match found anywhere in list, will break out of loop
                if (isChecked == true)
                {
                    doesExist = true;
                    break;
                }
            }

            return doesExist;
        }

        public bool checkingInputAge(string strnInput)
        {
            bool isLength = false;

            if (strnInput.Length == 2)
            {
                isLength = true;
            }

            return isLength;
        }

        public bool checkAgeDigitLength(string strAge)
        {
            bool isLength = false;

            if(strAge.Length == 2)
            {
                isLength = true;
            }

            return isLength;
        }
    }
}

