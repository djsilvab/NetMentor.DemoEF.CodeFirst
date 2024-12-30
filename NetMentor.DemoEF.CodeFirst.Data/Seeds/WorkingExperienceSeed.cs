using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Seeds
{
    public class WorkingExperienceSeed : IEntityTypeConfiguration<WorkingExperience>
    {
        public void Configure(EntityTypeBuilder<WorkingExperience> builder)
        {
            builder.HasQueryFilter(c => c.State > 0);
        }
    }
}
