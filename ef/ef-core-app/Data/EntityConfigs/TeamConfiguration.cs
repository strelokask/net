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
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.HomeMatches)
                .WithOne(x => x.HomeTeam)
                .HasForeignKey(x => x.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AwayMatches)
                .WithOne(x => x.AwayTeam)
                .HasForeignKey(x => x.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Team()
                {
                    Id = 1,
                    Name = "Team 1",
                    CoachId = 1
                },
                new Team()
                {
                    Id = 2,
                    Name = "Team 2",
                    CoachId = 2
                },
                new Team()
                {
                    Id = 3,
                    Name = "Team 3",
                    CoachId = 3
                }
            );
        }
    }
}
