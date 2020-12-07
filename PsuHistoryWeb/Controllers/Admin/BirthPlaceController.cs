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
    [Route("admin/burial/birth-place")]
    [ApiController]
    [Authorize]
    public class BirthPlaceController : Controller
    {
        IService<BirthPlace> _service;

        public BirthPlaceController(IService<BirthPlace> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BirthPlace()
        {
            var birthPlaces = await _service.GetAllAsync();
            return View("~/Views/Admin/BirthPlace/Index.cshtml", birthPlaces);
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("~/Views/Admin/BirthPlace/Add.cshtml");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] BirthPlace birthPlace)
        {
            if (birthPlace.Place == null)
            {
                ModelState.AddModelError("Place", "Введите значение");
                return View("~/Views/Admin/BirthPlace/Add.cshtml", birthPlace);
            }

            if (!await _service.CreateAsync(birthPlace))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/BirthPlace/Add.cshtml", birthPlace);
            }

            return RedirectToAction("BirthPlace");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var birthPlace = await _service.GetAsync(id);
            return View("~/Views/Admin/BirthPlace/Edit.cshtml", birthPlace);
        }

        [HttpPut("{id}")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] BirthPlace birthPlace, [FromRoute] int id)
        {
            birthPlace.Id = id;

            if (birthPlace.Place == null)
            {
                ModelState.AddModelError("Place", "Введите значение");
                return View("~/Views/Admin/BirthPlace/Edit.cshtml", birthPlace);
            }

            if (!await _service.UpdateAsync(birthPlace))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/BirthPlace/Edit.cshtml", birthPlace);
            }

            return RedirectToAction("BirthPlace");
        }


        [HttpGet]
        [Route("look/{id}")]
        public async Task<IActionResult> Look([FromRoute] int id)
        {
            var birthPlace = await _service.GetAsync(id);
            return View("~/Views/Admin/BirthPlace/Look.cshtml", birthPlace);
        }


        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("BirthPlace");
        }
    }
}
