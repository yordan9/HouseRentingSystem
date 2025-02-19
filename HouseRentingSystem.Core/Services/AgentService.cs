using HouseRentingSystem.Core.Contract;
using HouseRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly ApplicationDbContext data;

        public AgentService(ApplicationDbContext _data)
        {
            this.data = _data;
        }

        public async Task Create(string userID, string phoneNumber)
        {
            await data.AddAsync(new Agent()
            {
                UserId = userID,
                PhoneNumber = phoneNumber
            });
            await data.SaveChangesAsync();
        }

        public async Task<bool> ExistById(string userId)
        {
            return await data.Agents.AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetAgentId(string userId)
        {
            return data.Agents.FirstOrDefault(a => a.UserId == userId)?.Id;
        }

        public Task<bool> UserHasRent(string userId)
        {
            return data.Houses.AnyAsync(h => h.RenterId == userId);
        }

        public Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return data.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
