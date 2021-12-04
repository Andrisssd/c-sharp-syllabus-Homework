using System;

namespace Firm
{
    public class Staff
    {
        StaffMember[] staffList;

        //-----------------------------------------------------------------
        // Sets up the list of staff members.
        //-----------------------------------------------------------------
        public Staff()
        {
            staffList = new StaffMember[8];
            staffList[0] = new Executive("Sam", "123 Main Line",
                "555-0469", "123-45-6789", 2423.07);
            staffList[1] = new Employee("Carla", "456 Off Line",
                "555-0101", "987-65-4321", 1246.15);
            staffList[2] = new Employee("Woody", "789 Off Rocker",
                "555-0000", "010-20-3040", 1169.23);
            staffList[3] = new Hourly("Diane", "678 Fifth Ave.",
                "555-0690", "958-47-3625", 10.55);
            staffList[4] = new Volunteer("Norm", "987 Suds Blvd.",
                "555-8374");
            staffList[5] = new Volunteer("Cliff", "321 Duds Lane",
                "555-7282");
            staffList[6] = new Commissions("Andris", "333 Blvd.", "555-8888", "333-33-3333", 6.25, 0.2f);
            staffList[7] = new Commissions("Agris", "444 Blvd.", "666-9999", "222-22-2222", 9.75, 0.15f);
            ((Executive) staffList[0]).AwardBonus(500.00);
            ((Hourly) staffList[3]).AddHours(40);
            ((Commissions)staffList[6]).AddHours(35);
            ((Commissions)staffList[6]).AddSales(400);
            ((Commissions)staffList[7]).AddHours(40);
            ((Commissions)staffList[7]).AddSales(950);
        }

        //-----------------------------------------------------------------
        // Pays all staff members.
        //-----------------------------------------------------------------
        public void Payday()
        {
            foreach (var staff in staffList)
            {
                Console.WriteLine(staff);
                var amount = staff.Pay();
                if (amount == 0.00)
                    Console.WriteLine("Thanks!");
                else
                    Console.WriteLine("Paid: " + amount);
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}