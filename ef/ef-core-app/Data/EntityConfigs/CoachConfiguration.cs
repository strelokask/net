using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityConfigs
{
    internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData(
                new Coach()
                {
                    Id = 1,
                    Name = "Coach 1",
                },
                new Coach()
                {
                    Id = 2,
                    Name = "Coach 2",
                },
                new Coach()
                {
                    Id = 3,
                    Name = "Coach 3",
                }
            );
        }
    }
}
