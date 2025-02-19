﻿using HouseRentingSystem.Core.Contract;
using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using HouseRentingSystem.Infrastructure.ClaimPrincipalExtensions;

namespace HouseRentingSystem.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;
        
        public AgentController(IAgentService _agentService)
        {
            this.agentService = _agentService;
        }

        //В _LoginPartial.cshtml и _Leyout.cshtml са добавени няколко <li> към навигационното меню, както и проверка за автентикация
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Този ред извлича уникалния идентификатор (ID) на текущия потребител от ClaimsPrincipal (User), използвайки ClaimTypes.NameIdentifier
            //За да не го пишем всеки път 
            //използваме краткото User.Id(), което сме заявили в ClaimsPrincipalExtension.
            if(User.Id == null)
            {
                return Unauthorized();
            }
            if(await agentService.ExistById(User.Id()))
            {
                return BadRequest();
            }
            var model = new BecomeAgentFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            //Проверява дали телефонният номер вече се използва.
            if(await agentService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
                //Извличаме съобщението PhoneExists от статичен клас MassageConstants, който сме създали в Core слоя.
            }
            //Проверява дали потребителят има активни наеми.
            if(await agentService.UserHasRent(User.Id())) //извличаме User.Id() от ClaimsPrincipalExtension
            {
                ModelState.AddModelError("Error", HasRents);
            }
            //Ако има грешки, връща формата с показани грешки.
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            //Ако всичко е наред, създава нов агент и пренасочва потребителя към друга страница.
            await agentService.Create(User.Id(), model.PhoneNumber);
            return RedirectToAction(nameof(HomeController.Index), "House");
        }
    }
}
