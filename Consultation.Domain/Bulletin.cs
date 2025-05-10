using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class Bulletin
    {

        [Key]
        public int BulletinID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public DateTime DatePublished { get; set; }

        public int Priority { get; set; }

        public string Notify { get; set; }
        
    }
}
