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

        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repo.AllReadOnly<Agent>()
                 .AnyAsync(a => a.UserId == userId);
        }

        public Task<bool> UserHasRentsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWhitPhoneNumberExistAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
