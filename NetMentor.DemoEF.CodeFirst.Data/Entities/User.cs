using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Entities
{
    public class User
    {        
        
        public int Id { get; set; }        
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }       

        public ICollection<WorkingExperience> WorkingExperiences { get; set; }
    }
}
