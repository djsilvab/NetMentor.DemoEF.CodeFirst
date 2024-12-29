using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.Models
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public byte State { get; set; }
        [ConcurrencyCheck]
        public DateTime LastUpdateTimeUtc { get; set; }
        public DateTime? DeletedTimeUtc { get; set; }
    }
}
