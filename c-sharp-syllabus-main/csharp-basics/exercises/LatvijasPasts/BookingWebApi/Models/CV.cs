using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingWebApi.Models
{
    public class CV
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Adress Adress { get; set; }
        public Work Work { get; set; }
        public Education Education { get; set; }
    }

    public class Adress
    {
        public string Country { get; set; }
        public string Index { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
    }

    //public struct WorkHistory
    //{
    //    public List<Work> WorkList;
    //    public void AddWork(Work work)
    //    {
    //        WorkList.Add(work);
    //    }
    //}

    //public struct EducationHistory
    //{
    //    public List<Education> EducationList;
    //    public void AddEdication(Education education)
    //    {
    //        EducationList.Add(education);
    //    }
    //}

    public class Education
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string FieldOfStudy { get; set; }
        public string DailySpentTime { get; set; }
        public EducationStatus? Status { get; set; }
    }
    
    public enum EducationStatus
    {
        Completed, InProgress, Incompleted
    }

    public class Work
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string WorkLoad { get; set; }
        public string TotalTimeSpentWorking { get; set; }
        public string DailySpentTime { get; set; }
    }
}