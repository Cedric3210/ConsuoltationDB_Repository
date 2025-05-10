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

        [ForeignKey(nameof(StudentID))]
        public int StudentID { get; set; }

        [ForeignKey(nameof(FacultyID))]
        public int FacultyID { get; set; }

        public virtual Student Student { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual Courses Course { get; set; }  


    }
}
