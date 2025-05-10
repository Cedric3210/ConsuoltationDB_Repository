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
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int UserID { get; set; }
        
        public string UMID { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public UserType UserType { get; set; }
        
        public virtual Admin Admin { get; set; }
        public virtual Student Student { get; set; }
        public virtual Faculty Faculty { get; set; }
        
        //add sd ni
        //public ICollection<ActionLog> ActionLogs { get; set; }
    }
}
