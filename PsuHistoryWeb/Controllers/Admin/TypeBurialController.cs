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
    [Route("admin/burial/type-burial")]
    [ApiController]
    [Authorize]
    public class TypeBurialController : Controller
    {
        IService<TypeBurial> _service;

        public TypeBurialController(IService<TypeBurial> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> TypeBurial()
        {
            var typeBurials = await _service.GetAllAsync();
            return View("~/Views/Admin/TypeBurial/Index.cshtml", typeBurials);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("~/Views/Admin/TypeBurial/Add.cshtml");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] TypeBurial typeBurial)
        {
            if (typeBurial.Name == null)
            {
                ModelState.AddModelError("Name", "Введите значение");
                return View("~/Views/Admin/TypeBurial/Add.cshtml", typeBurial);
            }

            if (!await _service.CreateAsync(typeBurial))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/TypeBurial/Add.cshtml", typeBurial);
            }

            return RedirectToAction("TypeBurial");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var typeBurial = await _service.GetAsync(id);
            return View("~/Views/Admin/TypeBurial/Edit.cshtml", typeBurial);
        }

        [HttpPut("{id}")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] TypeBurial typeBurial, [FromRoute] int id)
        {
            typeBurial.Id = id;

            if (typeBurial.Name == null)
            {
                ModelState.AddModelError("Name", "Введите значение");
                return View("~/Views/Admin/TypeBurial/Edit.cshtml", typeBurial);
            }

            if (!await _service.UpdateAsync(typeBurial))
            {
                ModelState.AddModelError("", "Уже существует");
                return View("~/Views/Admin/TypeBurial/Edit.cshtml", typeBurial);
            }

            return RedirectToAction("TypeBurial");
        }


        [HttpGet]
        [Route("look/{id}")]
        public async Task<IActionResult> Look([FromRoute] int id)
        {
            var typeBurial = await _service.GetAsync(id);
            return View("~/Views/Admin/TypeBurial/Look.cshtml", typeBurial);
        }


        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("TypeBurial");
        }
    }
}
