using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repo;

        public AgentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repo.AddAsync(new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repo.AllReadOnly<Agent>()
                 .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetAgentIdAsync(string userId)
        {
            return (await repo.AllReadOnly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await repo.AllReadOnly<House>()
                 .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWhitPhoneNumberExistAsync(string phoneNumber)
        {
            return await repo.AllReadOnly<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }


    }
}
