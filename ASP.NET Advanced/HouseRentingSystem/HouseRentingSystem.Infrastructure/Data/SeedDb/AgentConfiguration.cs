using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data.SeedDb
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Agent> builder)
        {
            var data = new SeedData();

            builder.HasData(new Agent[] { data.Agent });
        }
    }
}
