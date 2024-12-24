using System.ComponentModel.DataAnnotations;

namespace NetMentor.DemoEF.CodeFirst.Entities.Models
{
    public class WorkingExperience : BaseEntity<int>
    {        
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Details { get; set; }
        public string Environment { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
