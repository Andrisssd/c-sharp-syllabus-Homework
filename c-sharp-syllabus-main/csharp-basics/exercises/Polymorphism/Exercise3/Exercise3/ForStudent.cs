using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Student : Person
    {
        private double _GPA;
        public Student(string firstName, string lastName, string adress, int id, double GPA) : base(firstName, lastName, adress, id)
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

}
