using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class EnrolledCourse
    {
        [Key]
        public string EnrolledCourseID { get; set; }

        public string CourseCode { get; set; }

        [ForeignKey(nameof(CourseID))]
        public int CourseID { get; set; }
        public virtual Courses Course { get; set; }
        
        [ForeignKey(nameof(SchoolYearID))]
        public int SchoolYearID { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        
        //dli na need tanan sa baba kay redundant na, ma-access na nag student/faculty thru SY
        [ForeignKey(nameof(StudentID))]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        
        [ForeignKey(nameof(FacultyID))]
        public int FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
