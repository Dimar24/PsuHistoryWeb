using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Models;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;

namespace PsuHistoryWeb.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : Controller
    {
        IUnitOfWork _database;
        IService<Burial> _service;

        public HomeController(IService<Burial> service, IUnitOfWork database)
        {
            _service = service;
            _database = database;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var burials = await _service.GetAllAsync();
            return View(burials);
        }


        [HttpGet]
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }


        [HttpGet]
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        [Route("burial/{id}")]
        public async Task<IActionResult> GetBurial([FromRoute] int id)
        {
            var burial = await _service.GetAsync(id);
            return View(burial);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
