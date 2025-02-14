using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Contract
{
    internal interface IAgentService
    {
        Task<bool> ExistById(string userId);
        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        Task<bool> UserHasRent(string userId);
        Task Create(string userId, string phoneNumber);
        Task<int?> GetAgentId(string userId);
    }
}
