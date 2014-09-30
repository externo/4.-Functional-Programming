using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Student
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student> 
            {
                new Student(
                    "Petar",
                    "Petrov",
                    23,
                    "800014",
                    "+359888456123",
                    "alabala@dir.bg",
                    2,
                    "Plovdiv",
                    new List<int>() { 2, 3, 4, 4, 6, 5, 6, 6 }),

                new Student(
                    "Emil",
                    "Emilov",
                    33,
                    "850014",
                    "+359 2555623",
                    "alabala@abv.bg",
                    1,
                    "Plovdiv",
                    new List<int>() { 6, 6, 6, 6, 6, 5, 6, 6 }),
            
                new Student(
                    "Zdravko",
                    "Ivanov",
                    17,
                    "734015",
                    "+35942456123",
                    "zizo@dir.bg",
                    2,
                    "Sofia",
                    new List<int>() { 2, 3, 4, 6, 6, 4, 5, 5, 5, 3, 2 }),

                new Student(
                    "Dinko",
                    "Dinev",
                    26,
                    "023016",
                    "+359888457873",
                    "didi@softuni.bg",
                    1,
                    "Sofia",
                    null),

                new Student(
                    "Samuil",
                    "Asparuhov",
                    19,
                    "800014",
                    "+359888456123",
                    "alabala@dir.bg",
                    2,
                    "Sofia",
                    new List<int>() { 2, 3, 4, 4, 6, 5, 6, 6 }),

                new Student(
                    "Gosho",
                    "Peshev",
                    33,
                    "851014",
                    "+359888555623",
                    "alabala@abv.bg",
                    1,
                    "Ruse",
                    new List<int>() { 6, 6, 6, 6, 6, 5, 6, 6 })
            };
            Console.WriteLine();
            var orderedStudents = 
                from s in studentList
                    orderby s.FirstName
                    select s;
            foreach (var o in orderedStudents)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();
            var alphabetStudents =
                from s in studentList
                where s.FirstName.CompareTo(s.LastName) < 0
                select s;
            foreach (var item in alphabetStudents)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var ageStudents =
                from s in studentList
                where s.Age >= 18 && s.Age <= 24
                select new { s.FirstName, s.LastName, s.Age };
            foreach (var item in ageStudents)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

        }
    }

    class Student
    {
        public Student(
        string firstName,
        string lastName,
        int age,
        string facultyNumber,
        string phone,
        string email,
        int groupNumber,
        string groupName,
        IList<int> marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.GroupNumber = groupNumber;
            if (null == marks)
            {
                this.Marks = new List<int>();
            }
            else
            {
                this.Marks = marks;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string FacultyNumber { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IList<int> Marks { get; set; }

        public int GroupNumber { get; set; }

        public override string ToString()
        {
            return "Student "+this.FirstName+" "+this.LastName +" is "+this.Age+" years old. "+
                "Has "+this.FacultyNumber+"fac.N and phone: "+this.Phone+" and e-mail: "+this.Email+
                ". Marks are - "+this.Marks+" and the group number is "+ this.GroupNumber;
        }
    }
}
