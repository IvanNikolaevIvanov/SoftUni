using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Statistics;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repo;

        public StatisticService(IRepository repository)
        {
            repo = repository;
        }

        public async Task<StatisticsServiceModel> TotalAsync()
        {
            int totalHouses = await repo.AllReadOnly<House>()
                .CountAsync();

            int totalRents = await repo.AllReadOnly<House>()
                .Where(h => h.RenterId != null)
                .CountAsync();

            return new StatisticsServiceModel()
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
    }
}
