using System;

namespace Exercise3
{
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
