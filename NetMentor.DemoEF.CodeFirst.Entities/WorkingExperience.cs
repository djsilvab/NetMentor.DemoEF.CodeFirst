using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities
{
    public class WorkingExperience
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }        
        public string Details { get; set; }
        public string Environment { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
