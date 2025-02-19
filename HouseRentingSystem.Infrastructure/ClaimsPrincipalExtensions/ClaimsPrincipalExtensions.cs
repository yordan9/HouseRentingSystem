using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Infrastructure.ClaimPrincipalExtensions
{
    /// <summary>
    /// Създаваш статичен клас с разширение (extension method), което добавя нов метод към ClaimsPrincipal.
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Разширява обекта ClaimsPrincipal с метода Id().
        /// <returns>ClaimTypes.NameIdentifier(UserId)</returns>
        public static string? Id(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
