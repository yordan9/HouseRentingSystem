using HouseRentingSystem.Core.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize] //трябва да си ауторизиран за това
    public class HouseController : Controller
    {
        private readonly IHouseService house;

        public HouseController(IHouseService _house)
        {
            this.house = _house;
        }

        [AllowAnonymous] //разрешено за анонимни юзъри
        [HttpGet]
        public async Task<IActionResult> All([FromQuery HouseQueryServeceModel query])
        {
            var queryResult = await house.AllHousesListAsync(
                query.Category);
            return View(queryResult);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await house.HouseDetails(id);
            return View(model);
        }
    }
}
