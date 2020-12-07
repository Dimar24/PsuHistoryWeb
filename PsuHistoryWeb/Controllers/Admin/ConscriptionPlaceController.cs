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
    [Route("admin/burial/conscription-place")]
    [ApiController]
    [Authorize]
    public class ConscriptionPlaceController : Controller
    {
        IService<ConscriptionPlace> _service;

        public ConscriptionPlaceController(IService<ConscriptionPlace> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ConscriptionPlace()
        {
            var conscriptionPlaces = await _service.GetAllAsync();
            return View("~/Views/Admin/ConscriptionPlace/Index.cshtml", conscriptionPlaces);
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("~/Views/Admin/ConscriptionPlace/Add.cshtml");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] ConscriptionPlace conscriptionPlace)
        {
            if (conscriptionPlace.Place == null)
            {
                ModelState.AddModelError("Place", "Введите значение");
                return View("~/Views/Admin/ConscriptionPlace/Add.cshtml", conscriptionPlace);
            }

            if (!await _service.CreateAsync(conscriptionPlace))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/ConscriptionPlace/Add.cshtml", conscriptionPlace);
            }

            return RedirectToAction("ConscriptionPlace");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var conscriptionPlace = await _service.GetAsync(id);
            return View("~/Views/Admin/ConscriptionPlace/Edit.cshtml", conscriptionPlace);
        }

        [HttpPut("{id}")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] ConscriptionPlace conscriptionPlace, [FromRoute] int id)
        {
            conscriptionPlace.Id = id;

            if (conscriptionPlace.Place == null)
            {
                ModelState.AddModelError("Place", "Введите значение");
                return View("~/Views/Admin/ConscriptionPlace/Edit.cshtml", conscriptionPlace);
            }

            if (!await _service.UpdateAsync(conscriptionPlace))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/ConscriptionPlace/Edit.cshtml", conscriptionPlace);
            }

            return RedirectToAction("ConscriptionPlace");
        }


        [HttpGet]
        [Route("look/{id}")]
        public async Task<IActionResult> Look([FromRoute] int id)
        {
            var conscriptionPlace = await _service.GetAsync(id);
            return View("~/Views/Admin/ConscriptionPlace/Look.cshtml", conscriptionPlace);
        }


        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("ConscriptionPlace");
        }
    }
}
