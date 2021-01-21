using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsuHistoryWeb.Controllers.Admin
{
    [Route("admin/burial/victim")]
    [ApiController]
    [Authorize]
    public class VictimController : Controller
    {
        IUnitOfWork _database;
        IService<Victim> _service;

        public VictimController(IService<Victim> service, IUnitOfWork database)
        {
            _service = service;
            _database = database;
        }

        [HttpGet]
        public async Task<IActionResult> Victim()
        {
            var victims = await _service.GetAllAsync();
            return View("~/Views/Admin/Victim/Index.cshtml", victims);
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> Add()
        {
            SelectList typeVictims = new SelectList(await _database.TypeVictims.GetAllAsync(), "Id", "Name");
            ViewBag.TypeVictims = typeVictims;

            SelectList dutyStations = new SelectList(await _database.DutyStations.GetAllAsync(), "Id", "Place");
            ViewBag.DutyStations = dutyStations;

            SelectList birthPlaces = new SelectList(await _database.BirthPlaces.GetAllAsync(), "Id", "Place");
            ViewBag.BirthPlaces = birthPlaces;

            SelectList conscriptionPlaces = new SelectList(await _database.ConscriptionPlaces.GetAllAsync(), "Id", "Place");
            ViewBag.ConscriptionPlaces = conscriptionPlaces;

            SelectList burials = new SelectList(await _database.Burials.GetAllAsync(), "Id", "NumberBurial");
            ViewBag.Burials = burials;

            return View("~/Views/Admin/Victim/Add.cshtml");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] Victim victim)
        {
            if (!await _service.CreateAsync(victim))
            {
                ModelState.AddModelError("", "Уже существует");

                SelectList typeVictims = new SelectList(await _database.TypeVictims.GetAllAsync(), "Id", "Name");
                ViewBag.TypeVictims = typeVictims;

                SelectList dutyStations = new SelectList(await _database.DutyStations.GetAllAsync(), "Id", "Place");
                ViewBag.DutyStations = dutyStations;

                SelectList birthPlaces = new SelectList(await _database.BirthPlaces.GetAllAsync(), "Id", "Place");
                ViewBag.BirthPlaces = birthPlaces;

                SelectList conscriptionPlaces = new SelectList(await _database.ConscriptionPlaces.GetAllAsync(), "Id", "Place");
                ViewBag.ConscriptionPlaces = conscriptionPlaces;

                SelectList burials = new SelectList(await _database.Burials.GetAllAsync(), "Id", "NumberBurial");
                ViewBag.Burials = burials;

                return View("~/Views/Admin/Victim/Add.cshtml", victim);
            }

            return RedirectToAction("Victim");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var conscriptionPlace = await _service.GetAsync(id);

            SelectList typeVictims = new SelectList(await _database.TypeVictims.GetAllAsync(), "Id", "Name");
            ViewBag.TypeVictims = typeVictims;

            SelectList dutyStations = new SelectList(await _database.DutyStations.GetAllAsync(), "Id", "Place");
            ViewBag.DutyStations = dutyStations;

            SelectList birthPlaces = new SelectList(await _database.BirthPlaces.GetAllAsync(), "Id", "Place");
            ViewBag.BirthPlaces = birthPlaces;

            SelectList conscriptionPlaces = new SelectList(await _database.ConscriptionPlaces.GetAllAsync(), "Id", "Place");
            ViewBag.ConscriptionPlaces = conscriptionPlaces;

            SelectList burials = new SelectList(await _database.Burials.GetAllAsync(), "Id", "NumberBurial");
            ViewBag.Burials = burials;

            return View("~/Views/Admin/Victim/Edit.cshtml", conscriptionPlace);
        }

        [HttpPut("{id}")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] Victim victim, [FromRoute] int id)
        {
            victim.Id = id;

            if (!await _service.UpdateAsync(victim))
            {
                ModelState.AddModelError("", "Уже существует");

                SelectList typeVictims = new SelectList(await _database.TypeVictims.GetAllAsync(), "Id", "Name");
                ViewBag.TypeVictims = typeVictims;

                SelectList dutyStations = new SelectList(await _database.DutyStations.GetAllAsync(), "Id", "Place");
                ViewBag.DutyStations = dutyStations;

                SelectList birthPlaces = new SelectList(await _database.BirthPlaces.GetAllAsync(), "Id", "Place");
                ViewBag.BirthPlaces = birthPlaces;

                SelectList conscriptionPlaces = new SelectList(await _database.ConscriptionPlaces.GetAllAsync(), "Id", "Place");
                ViewBag.ConscriptionPlaces = conscriptionPlaces;

                SelectList burials = new SelectList(await _database.Burials.GetAllAsync(), "Id", "NumberBurial");
                ViewBag.Burials = burials;

                return View("~/Views/Admin/Victim/Edit.cshtml", victim);
            }

            return RedirectToAction("Victim");
        }

        [HttpGet]
        [Route("look/{id}")]
        public async Task<IActionResult> Look([FromRoute] int id)
        {
            var victim = await _service.GetAsync(id);
            return View("~/Views/Admin/Victim/Look.cshtml", victim);
        }


        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Victim");
        }
    }
}
