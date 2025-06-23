using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }

        public string FacultyUMID { get; set; }
  
        public string FacultyName { get; set; }

        public Users Users { get; set; }


        //not needed
        [ForeignKey(nameof(EnrolledCourseID))]
        public int EnrolledCourseID { get; set; }
        public virtual EnrolledCourse EnrolledCourse { get; set; }

        //di nsd ni need na FK
        [ForeignKey(nameof(FacultyScheduleID))]
        public int FacultyScheduleID { get; set; }
        //kani pabilin
        public virtual FacultySchedule FacultySchedule { get; set; }
        
        //change to ICollection<>
        public List<ConsultationRequest> ConsultationRequests { get; set; }
        //add sad
        public SchoolYear SchoolYears { get; set; }
    }
}
