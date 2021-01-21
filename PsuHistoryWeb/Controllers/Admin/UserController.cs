using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Controllers.Admin
{
    [Route("admin/burial/type-victim")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        //IService<TypeVictim> _service;

        public UserController(/*IService<TypeVictim> service*/)
        {
            //_service = service;
        }

        //[HttpGet]
        //public async Task<IActionResult> TypeVictim()
        //{
        //    var typeVictims = await _service.GetAllAsync();
        //    return View("~/Views/Admin/TypeVictim/Index.cshtml", typeVictims);
        //}

        //[HttpGet]
        //[Route("add")]
        //public IActionResult Add()
        //{
        //    return View("~/Views/Admin/TypeVictim/Add.cshtml");
        //}

        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> Add([FromForm] TypeVictim typeVictim)
        //{
        //    if (typeVictim.Name == null)
        //    {
        //        ModelState.AddModelError("Name", "Введите значение");
        //        return View("~/Views/Admin/TypeVictim/Add.cshtml", typeVictim);
        //    }

        //    if (!await _service.CreateAsync(typeVictim))
        //    {
        //        ModelState.AddModelError("", "Уже существует");
        //        return View("~/Views/Admin/TypeVictim/Add.cshtml", typeVictim);
        //    }

        //    return RedirectToAction("TypeVictim");
        //}


        //[HttpGet]
        //[Route("edit/{id}")]
        //public async Task<IActionResult> Edit([FromRoute] int id)
        //{
        //    var typeVictim = await _service.GetAsync(id);
        //    return View("~/Views/Admin/TypeVictim/Edit.cshtml", typeVictim);
        //}

        //[HttpPut("{id}")]
        //[Route("edit/{id}")]
        //public async Task<IActionResult> Edit([FromForm] TypeVictim typeVictim, [FromRoute] int id)
        //{
        //    typeVictim.Id = id;

        //    if (typeVictim.Name == null)
        //    {
        //        ModelState.AddModelError("Name", "Введите значение");
        //        return View("~/Views/Admin/TypeVictim/Edit.cshtml", typeVictim);
        //    }

        //    if (!await _service.UpdateAsync(typeVictim))
        //    {
        //        ModelState.AddModelError("", "Уже существует");
        //        return View("~/Views/Admin/TypeVictim/Edit.cshtml", typeVictim);
        //    }

        //    return RedirectToAction("TypeVictim");
        //}


        //[HttpGet]
        //[Route("look/{id}")]
        //public async Task<IActionResult> Look([FromRoute] int id)
        //{
        //    var typeVictim = await _service.GetAsync(id);
        //    return View("~/Views/Admin/TypeVictim/Look.cshtml", typeVictim);
        //}


        //[HttpDelete("{id}")]
        //[Route("delete/{id}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    await _service.DeleteAsync(id);
        //    return RedirectToAction("TypeVictim");
        //}
    }
}
