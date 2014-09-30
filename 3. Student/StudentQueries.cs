using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Student
{
    class StudentQueries
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
            List<StudentSpecialty> specialtyList = new List<StudentSpecialty> 
            {
                new StudentSpecialty(
                    "Web Developer",
                    "800014"
                    ),

                new StudentSpecialty(
                    "Web Developer",
                    "850014"
                    ),
            
                new StudentSpecialty(
                    "PHP Developer",
                    "734015"
                    ),

                new StudentSpecialty(
                    "PHP Developer",
                    "023016"
                    ),

                new StudentSpecialty(
                    "C# Developer",
                    "800014"
                    ),

                new StudentSpecialty(
                    "Java Developer",
                    "851014"
                    )
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
            var orderByName = studentList.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);
            foreach (var item in orderByName)
            {
                Console.WriteLine("reverse order by first and last name: "+item);
            }
            Console.WriteLine();
            var orderByNameQuery =
                from s in studentList
                orderby s.FirstName descending, s.LastName descending
                select s;
            //var ln = from s in orderByNameQuery
            //         orderby s.LastName descending
            //         select s;
            foreach (var i in orderByNameQuery)
            {
                Console.WriteLine("QUERY reverse order by first and last name: " + i);
            }
            Console.WriteLine();
            var abvStudents =
                from s in studentList
                where s.Email.EndsWith("@abv.bg")
                select s;
            foreach (var i in abvStudents)
            {
                Console.WriteLine("ABV: " + i);
            }
            Console.WriteLine();
            //02 / +3592 / +359 2
            var sofiaCodes = new[]{"02", "+3592", "+359 2"};
            var sofiaStudents =
                from s in studentList
                from c in sofiaCodes
                where s.Phone.StartsWith(c)
                select s;
            foreach (var i in sofiaStudents)
            {
                Console.WriteLine("sofiaCODE: " + i);
            }
            Console.WriteLine();
            var excellentStudents =
                from s in studentList
                where s.Marks.Contains(6)
                select new { FullName = s.FirstName + s.LastName, Marks = s.Marks };
            foreach (var i in excellentStudents)
            {
                Console.WriteLine("6 mark: " + i.ToString());
            }
            Console.WriteLine();
            var weakStudents =
                from s in studentList
                where s.Marks.Where(m => m == 2).Count() == 2
                select s;
            foreach (var i in weakStudents)
            {
                Console.WriteLine("2 mark: " + i.ToString());
            }
            Console.WriteLine();
            var students2014 =
                from s in studentList
                where s.FacultyNumber.Substring(4, 2) == "14"
                select s.Marks;
            foreach (var marks in students2014)
            {
                Console.Write("marks: ");
                foreach (var m in marks)
                {
                    Console.Write(m+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            var groups =
                from s in studentList
                group s by s.GroupNumber into gs
                select new { GroupName = gs.Key, Students = gs };
            foreach (var group in groups)
            {
                Console.WriteLine("group:   "+group.GroupName);
                foreach (var i in group.Students)
	            {
		            Console.WriteLine(" "+i);
	            }
                Console.WriteLine();
            }
            Console.WriteLine();
            var groupsLAMBDA = studentList.GroupBy(s => s.GroupNumber);
            foreach (var group in groupsLAMBDA)
            {
                Console.WriteLine("LAMBDAgroup:   " + group.Key);
                foreach (var i in group)
                {
                    Console.WriteLine(" " + i);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            var studentFacs =
                from s in studentList
                select new { Name = s.FirstName + " " + s.LastName, FN = s.FacultyNumber };
            var specialtyFacs =
                from f in specialtyList
                select new { Specialty = f.Specialty, FN = f.FacultyNumber };
            var join =
                from s in studentFacs
                join f in specialtyFacs on s.FN equals f.FN into newGroup
                select new { Name = s.Name, Specialty = newGroup };
            foreach (var item in join)
            {
                Console.Write(item.Name + "  ");
                foreach (var i in item.Specialty)
	            {
		            Console.Write(i.FN+"  "+i.Specialty);
	            }
                Console.WriteLine();
            }
            //from category in categories
            //join prod in products on category.ID equals prod.CategoryID into prodGroup
            //select new { CategoryName = category.Name, Products = prodGroup };
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

    class StudentSpecialty
    {
        public StudentSpecialty(string specialty, string facultyNumber)
        {
            this.Specialty = specialty;
            this.FacultyNumber = facultyNumber;
        }

        public string Specialty { get; set; }
        public string FacultyNumber { get; set; }
    }
}
