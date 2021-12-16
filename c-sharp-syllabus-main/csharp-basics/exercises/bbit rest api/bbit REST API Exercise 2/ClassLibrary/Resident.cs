using System;

namespace ClassLibrary
{
    public class Resident 
    {
        public string UniqueId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public Flat LivingFlat { get; set; }
    }
}
