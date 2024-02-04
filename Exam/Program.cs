using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<int> Grades { get; set; }

        public Student(string firstName, string lastName, DateTime birthDate, List<int> grades)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Grades = grades;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, BirthDate: {BirthDate.ToShortDateString()}, Grades: {string.Join(", ", Grades)}";
        }
    }

    class University
    {
        public List<Student> Students { get; set; }

        public University(List<Student> students)
        {
            Students = students;
        }

        public void PrintAllStudents()
        {
            foreach (var student in Students)
            {
                Console.WriteLine(student);
            }
        }

        public void PrintAllStudentsAlphabetically()
        {
            var sortedStudents = Students.OrderBy(s => s.FirstName).ThenBy(s => s.LastName).ToList();
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        public Student GetMostSuccessfulStudent()
        {
            return Students.OrderByDescending(s => s.Grades.Average()).FirstOrDefault();
        }

        public List<Student> GetStudentsByName(string name)
        {
            return Students.Where(s => s.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Student> GetBirthdayStudents(DateTime date)
        {
            return Students.Where(s => s.BirthDate.Month == date.Month && s.BirthDate.Day == date.Day).ToList();
        }
    }

    class Program
    {
        static void Main()
        {
            var students = new List<Student>
        {
            new Student("John", "Doe", new DateTime(1995, 5, 15), new List<int> { 90, 85, 88 }),
            new Student("Alice", "Smith", new DateTime(1993, 8, 25), new List<int> { 78, 92, 87 }),
            new Student("Bob", "Johnson", new DateTime(1998, 2, 10), new List<int> { 95, 89, 91 }),
        };

            var university = new University(students);

            Console.WriteLine("All Students:");
            university.PrintAllStudents();

            Console.WriteLine("\nAll Students Alphabetically:");
            university.PrintAllStudentsAlphabetically();

            Console.WriteLine("\nMost Successful Student:");
            Console.WriteLine(university.GetMostSuccessfulStudent());

            Console.WriteLine("\nStudents Named Alice:");
            university.GetStudentsByName("Alice").ForEach(Console.WriteLine);

            Console.WriteLine("\nBirthday Students on 25th August:");
            university.GetBirthdayStudents(new DateTime(DateTime.Now.Year, 8, 25)).ForEach(Console.WriteLine);
        }
    }
}