using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMT.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string School { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [Display(Name = "Family Size")]
        public string FamSize { get; set; }
        public string Pstatus { get; set; }
        public int MEdu { get; set; }
        public int FEdu { get; set; }
        public string Reason { get; set; }
        public string Guardian { get; set; }
        [Display(Name = "Travel Time")]
        public int TravelTime { get; set; }
        [Display(Name = "Study Time")]
        public int StudyTime { get; set; }
        public int Failures { get; set; }
        public string SchoolSupport { get; set; }
        public string FamSupport { get; set; }
        public string Paid { get; set; }
        public string Activities { get; set; }
        public string Nursery { get; set; }
        public string Higher { get; set; }
        public string Internet { get; set; }
        public string Romantic { get; set; }
        public int FamilyRel { get; set; }
        [Display(Name = "Free Time")]
        public int FreeTime { get; set; }
        public int GoOut { get; set; }
        public int DailyAlc { get; set; }
        public int WeekAlc { get; set; }
        public int Health { get; set; }
        public int Absences { get; set; }
        [Display(Name = "First Period Grade")]
        public int G1 { get; set; }
        [Display(Name = "Second Period Grade")]
        public int G2 { get; set; }
        [Display(Name = "Final Grade")]
        public int G3 { get; set; }

    }
}