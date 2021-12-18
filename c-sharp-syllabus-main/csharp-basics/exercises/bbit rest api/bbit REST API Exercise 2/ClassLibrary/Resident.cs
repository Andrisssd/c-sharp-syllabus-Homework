using System;
using System.Linq;

namespace ClassLibrary
{
    public class Resident : IValidatable
    {
        public string UniqueId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public Flat LivingFlat { get; set; }

        public bool IsValid()
        {
            return (PhoneNumber.ToString().Where(x => Char.IsDigit(x)).Count()==8 && PersonalCode.Contains("-") && PersonalCode.Length==13);
        }
    }
}
