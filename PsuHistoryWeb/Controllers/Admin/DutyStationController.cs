using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsuHistoryWeb.Controllers.Admin
{
    [Route("admin/burial/duty-station")]
    [ApiController]
    [Authorize]
    public class DutyStationController : Controller
    {
        IService<DutyStation> _service;

        public DutyStationController(IService<DutyStation> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> DutyStation()
        {
            var dutyStations = await _service.GetAllAsync();
            return View("~/Views/Admin/DutyStation/Index.cshtml", dutyStations);
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("~/Views/Admin/DutyStation/Add.cshtml");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] DutyStation dutyStation)
        {
            if (dutyStation.Place == null)
            {
                ModelState.AddModelError("Place", "Введите значение");
                return View("~/Views/Admin/DutyStation/Add.cshtml", dutyStation);
            }

            if (!await _service.CreateAsync(dutyStation))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/DutyStation/Add.cshtml", dutyStation);
            }

            return RedirectToAction("DutyStation");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var dutyStation = await _service.GetAsync(id);
            return View("~/Views/Admin/DutyStation/Edit.cshtml", dutyStation);
        }

        [HttpPut("{id}")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] DutyStation dutyStation, [FromRoute] int id)
        {
            dutyStation.Id = id;

            if (dutyStation.Place == null)
            {
                ModelState.AddModelError("Place", "Введите значение");
                return View("~/Views/Admin/DutyStation/Edit.cshtml", dutyStation);
            }

            if (!await _service.UpdateAsync(dutyStation))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/DutyStation/Edit.cshtml", dutyStation);
            }

            return RedirectToAction("DutyStation");
        }


        [HttpGet]
        [Route("look/{id}")]
        public async Task<IActionResult> Look([FromRoute] int id)
        {
            var dutyStation = await _service.GetAsync(id);
            return View("~/Views/Admin/DutyStation/Look.cshtml", dutyStation);
        }


        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("DutyStation");
        }
    }
}
