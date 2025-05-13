using Consultation.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class Users
    {
        
        [Key]
        public int UserID { get; set; }
        
        public string UMID { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public UserType UserType { get; set; }

        public int? AdminID { get; set; }
        [ForeignKey(nameof(AdminID)), InverseProperty(nameof(Admin.Users))]
        public Admin? Admin { get; set; }

        public int? FacultyID { get; set; }
        [ForeignKey(nameof(FacultyID)), InverseProperty(nameof(Faculty.Users))]
        public Faculty? Faculty { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey(nameof(StudentID)), InverseProperty(nameof(Student.Users))]
        public Student? Student { get; set; }

        //add sd ni
        //public ICollection<ActionLog> ActionLogs { get; set; }
    }
}
