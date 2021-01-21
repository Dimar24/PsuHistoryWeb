using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsuHistoryWeb.Domain.Entities.Users;
using PsuHistoryWeb.Models;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _service;


        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("reg")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> Register([FromForm] RegistrViewModel model)
        {
            var user = new User() { UserName = model.UserName };
            if (await _service.Register(user, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            var user = new User() { UserName = model.UserName };
            if (await _service.Login(user, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Hello");
        }
    }
}
