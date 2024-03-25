using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Enumerations;
using HouseRentingSystem.Core.Exceptions;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repo;

        public HouseService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<HouseQueryServiceModel> AllAsync(
            string? category = null, string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var housesToShow = repo.AllReadOnly<House>();

            if (category != null)
            {
                housesToShow = housesToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizeSearchTerm = searchTerm.ToLower();
                housesToShow = housesToShow
                    .Where(h => (
                       h.Title.ToLower().Contains(normalizeSearchTerm)
                    || h.Address.ToLower().Contains(normalizeSearchTerm)
                    || h.Description.ToLower().Contains(normalizeSearchTerm))
                    );
            }

            housesToShow = sorting switch
            {
                HouseSorting.Price => housesToShow
                .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesToShow
                .OrderBy(h => h.RenterId != null)
                .ThenByDescending(h => h.Id),
                _ => housesToShow // "_" means Default Value
                .OrderByDescending(h => h.Id)
            };

            var houses = await housesToShow
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectToHouseServiceModel()
                //.Select(h => new HouseServiceModel()
                //{
                //    Id = h.Id,
                //    Address = h.Address,
                //    ImageUrl = h.ImageUrl,
                //    IsRented = h.RenterId != null,
                //    PricePerMonth = h.PricePerMonth,
                //    Title = h.Title
                //})
                .ToListAsync();

            int totalHouses = await housesToShow.CountAsync();

            return new HouseQueryServiceModel()
            {
                Houses = houses,
                TotalHousesCount = totalHouses
            };
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repo.AllReadOnly<Category>()
                .Select(c => new HouseCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repo.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            return await repo.AllReadOnly<House>()
                 .Where(h => h.AgentId == agentId)
                 .ProjectToHouseServiceModel()
                 .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId)
        {
            return await repo.AllReadOnly<House>()
                .Where(h => h.RenterId == userId)
                .ProjectToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repo.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(HouseFormModel model, int agentId)
        {
            House house = new House()
            {
                Address = model.Address,
                AgentId = agentId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title
            };

            await repo.AddAsync(house);
            await repo.SaveChangesAsync();

            return house.Id;
        }

        public async Task DeleteAsync(int houseId)
        {
            await repo.DeleteAsync<House>(houseId);
            await repo.SaveChangesAsync();
        }

        public async Task EditAsync(int houseId, HouseFormModel model)
        {
            var house = await repo.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.Address = model.Address;
                house.CategoryId = model.CategoryId;
                house.Description = model.Description;
                house.ImageUrl = model.ImageUrl;
                house.PricePerMonth = model.PricePerMonth;
                house.Title = model.Title;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repo.AllReadOnly<House>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id)
        {
            var house = await repo.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseFormModel()
                {
                    Address = h.Address,
                    CategoryId = h.CategoryId,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title
                })
                .FirstOrDefaultAsync();

            if (house != null)
            {
                house.Categories = await AllCategoriesAsync();
            }

            return house;
        }

        public async Task<bool> HasAgentWithIdAsync(int houseId, string userId)
        {
            return await repo.AllReadOnly<House>()
                .AnyAsync(h => h.Id == houseId && h.Agent.UserId == userId);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
        {
            return await repo.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    Agent = new Models.Agent.AgentServiceModel()
                    {
                        Email = h.Agent.User.Email,
                        PhoneNumber = h.Agent.PhoneNumber
                    },
                    Category = h.Category.Name,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title
                })
                .FirstAsync();
        }

        public async Task<bool> IsRentedAsync(int houseId)
        {
            bool result = false;
            var house = await repo.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                result = house.RenterId != null;
            }

            return result;
        }

        public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
        {
            bool result = false;
            var house = await repo.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                result = house.RenterId == userId;
            }

            return result;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
        {
            return await repo
                .AllReadOnly<House>()
                .OrderByDescending(h => h.Id)
                .Take(3)
                .Select(h => new HouseIndexServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title
                })
                .ToListAsync();
        }

        public async Task LeaveAsync(int houseId, string userId)
        {
            var house = await repo.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                if (house.RenterId != userId)
                {
                    throw new UnauthorizedActionException("The user is not the renter.");
                }
                house.RenterId = null;
                await repo.SaveChangesAsync();
            }
        }

        public async Task RentAsync(int id, string userId)
        {
            var house = await repo.GetByIdAsync<House>(id);

            if (house != null)
            {
                house.RenterId = userId;
                await repo.SaveChangesAsync();
            }
        }
    }
}
