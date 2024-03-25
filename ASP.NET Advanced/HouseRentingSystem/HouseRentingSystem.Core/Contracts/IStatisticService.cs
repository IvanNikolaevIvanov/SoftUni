using HouseRentingSystem.Core.Statistics;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticsServiceModel> TotalAsync();
    }
}
