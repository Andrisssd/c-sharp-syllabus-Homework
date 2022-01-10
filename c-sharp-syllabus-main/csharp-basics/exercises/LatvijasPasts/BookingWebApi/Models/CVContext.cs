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
                Adress = new Adress { City = "",
                Country = "",
                HomeNumber = "",
                Index = "",
                Street = "",},
                Education = new Education
                {
                    DailySpentTime = "",
                    Faculty = "",
                    FieldOfStudy = "",
                    Name = "",
                    Status = EducationStatus.Completed,
                },
                Work = new Work
                {
                    DailySpentTime = "",
                    Name = "",
                    Position = "",
                    TotalTimeSpentWorking = "",
                    WorkLoad = "",
                },
            }) ;
            
            base.Seed(context);
        }
    }
}