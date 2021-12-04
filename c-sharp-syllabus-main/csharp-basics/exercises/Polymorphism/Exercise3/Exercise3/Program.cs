using System;

namespace Exercise3
{
    public class Student : Person
    {
        private double _GPA;
        public Student(string firstName, string lastName, string adress, int id, double GPA): base(firstName, lastName, adress, id)
        {
            _GPA = GPA; 
        }

        public double GPA { get => _GPA; set => value = _GPA; }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Current status: Student, GPA: {GPA}");
        }
    }

    public class Employee : Person
    {
        private string _jobTitle;
        public Employee(string firstName, string lastName, string adress, int id, string jobTitle) : base(firstName, lastName, adress, id)
        {
            _jobTitle = jobTitle;
        }

        public string JobTitle { get => _jobTitle; set => value = _jobTitle; }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Current status: Employee, Title: {JobTitle}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("*****", "#########", "@@@@@@@", 123123123, 9.8);
            Employee employee = new Employee("*****", "#########", "@@@@@@@", 123123123, "Manager");
            student.Display();
            employee.Display();
        }
    }
}
