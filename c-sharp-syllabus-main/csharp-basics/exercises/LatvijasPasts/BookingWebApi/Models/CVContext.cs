using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookingWebApi.Models
{
    public class CVContext : DbContext
    {
        public DbSet<CV> CVs { get; set; }
    }

    public class CVDbInitializer : DropCreateDatabaseAlways<CVContext>
    {
        protected override void Seed(CVContext context)
        {
            context.CVs.Add(new CV
            {
                Id = 1,
                FirstName = "Andris",
                LastName = "Kuliss",
                PhoneNumber = "86957403",
                Email = "Email@gmail.com",
                Adress = new Adress { City = "SomeCity",
                    Country = "ComeCountry",
                    HomeNumber = "SomeHomeNumber",
                    Index = "SomeIndex",
                    Street = "SomeStreet", },
                Education = new Education
                {
                    DailySpentTime = "4h",
                    Faculty = "SomeFaculty",
                    FieldOfStudy = "SomeFieldOfStudy",
                    Name = "SomeName",
                    Status = EducationStatus.Completed,
                },
                Work = new Work
                {
                    DailySpentTime = "8h",
                    Name = "SomeName",
                    Position = "SomePosition",
                    TotalTimeSpentWorking = "Half a year",
                },
            }) ;
            base.Seed(context);
        }
    }
}