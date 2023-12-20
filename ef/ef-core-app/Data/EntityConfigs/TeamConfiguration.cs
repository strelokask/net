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
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Team()
                {
                    Id = 1,
                    Name = "Team 1",
                },
                new Team()
                {
                    Id = 2,
                    Name = "Team 2",
                },
                new Team()
                {
                    Id = 3,
                    Name = "Team 3",
                }
            );
        }
    }
}
