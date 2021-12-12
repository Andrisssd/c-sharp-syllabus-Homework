using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Person
    {
        protected string _firstName;
        protected string _lastName;
        protected string _adress;
        protected int _id;
        public Person(string firstName, string lastName, string adress, int id)
        {
            _firstName = firstName;
            _lastName = lastName;
            _adress = adress;
            _id = id;
        }
        
        public string FirstName { get => _firstName; set => value = _firstName; }
        public string LastName { get => _lastName; set => value = _lastName; }
        public string Adress { get => _adress; set => value = _adress; }
        public int Id { get => _id; set => value = _id; }
        public virtual void Display()
        {
            Console.WriteLine($"Name: {FirstName}, LastName: {LastName}, Adress: {Adress}, Id: {Id}");
        }
    }
}
