using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemUsingLINQ
{
     class Student : IStudent
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(int studentId, string firstName, string lastName, int age)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        //enables to print class objects
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", StudentId, FirstName, LastName, Age);

        }
    }
}
