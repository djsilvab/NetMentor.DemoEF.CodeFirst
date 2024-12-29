using System.ComponentModel.DataAnnotations;

namespace NetMentor.DemoEF.CodeFirst.Entities.Models
{
    public class User : BaseEntity<int>
    {        
        public string UserName { get; set; }
        [MaxLength(50)]        
        public string Email { get; set; }        
        public virtual ICollection<WorkingExperience> WorkingExperiences { get; set; }
    }
}
