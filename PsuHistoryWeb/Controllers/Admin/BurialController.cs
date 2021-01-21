using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;

namespace PsuHistoryWeb.Controllers.Admin
{
    [Route("admin/burial/burial")]
    [ApiController]
    [Authorize]
    public class BurialController : Controller
    {
        IUnitOfWork _database;
        IService<Burial> _service;
        IWebHostEnvironment _appEnvironment;

        public BurialController(IService<Burial> service, IUnitOfWork database, IWebHostEnvironment appEnvironment)
        {
            _service = service;
            _database = database;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Burial()
        {
            var burials = await _service.GetAllAsync();
            return View("~/Views/Admin/Burial/Index.cshtml", burials);
        }


        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> Add()
        {
            SelectList typeBurials = new SelectList(await _database.TypeBurials.GetAllAsync(), "Id", "Name");
            ViewBag.TypeBurials = typeBurials;

            return View("~/Views/Admin/Burial/Add.cshtml");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] Burial burial, [FromForm] IFormFileCollection uploads)
        {
            if (!await _service.CreateAsync(burial))
            {
                ModelState.AddModelError("", "Уже существует");

                SelectList typeBurials = new SelectList(await _database.TypeBurials.GetAllAsync(), "Id", "Name");
                ViewBag.TypeBurials = typeBurials;

                return View("~/Views/Admin/Burial/Add.cshtml", burial);
            }

            var id = (await _service.FindAsync(burial)).Id;
            string path = "/files/save/burial/";

            foreach (var uploadedFile in uploads)
            {
                string fileName = Guid.NewGuid() + "." + uploadedFile.ContentType.Split("/")[1];

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path + fileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                    await _database.AttachmentBurials.CreateAsync(new AttachmentBurial() {
                        Path = path + fileName,
                        BurialId = id
                    });
                }
            }

            return RedirectToAction("Burial");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var burial = await _service.GetAsync(id);

            SelectList typeBurials = new SelectList(await _database.TypeBurials.GetAllAsync(), "Id", "Name");
            ViewBag.Attachment = (await _database.AttachmentBurials.GetAllAsync()).Where(a => a.BurialId == id);
            ViewBag.TypeBurials = typeBurials;

            return View("~/Views/Admin/Burial/Edit.cshtml", burial);
        }

        [HttpPut("{id}")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] Burial burial, [FromForm] IFormFileCollection uploads, [FromRoute] int id)
        {
            burial.Id = id;

            if (!await _service.UpdateAsync(burial))
            {
                ModelState.AddModelError("", "Уже существует");

                SelectList typeBurials = new SelectList(await _database.TypeBurials.GetAllAsync(), "Id", "Name");
                ViewBag.Attachment = (await _database.AttachmentBurials.GetAllAsync()).Where(a => a.BurialId == id);
                ViewBag.TypeBurials = typeBurials;

                return View("~/Views/Admin/Burial/Edit.cshtml", burial);
            }

            string path = "/files/save/burial/";

            foreach (var uploadedFile in uploads)
            {
                string fileName = Guid.NewGuid() + "." + uploadedFile.ContentType.Split("/")[1];

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path + fileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                    await _database.AttachmentBurials.CreateAsync(new AttachmentBurial()
                    {
                        Path = path + fileName,
                        BurialId = id
                    });
                }
            }

            return RedirectToAction("Burial");
        }


        [HttpGet]
        [Route("look/{id}")]
        public async Task<IActionResult> Look([FromRoute] int id)
        {
            var burial = await _service.GetAsync(id);
            ViewBag.Attachment = (await _database.AttachmentBurials.GetAllAsync()).Where(a => a.BurialId == id);
            return View("~/Views/Admin/Burial/Look.cshtml", burial);
        }


        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Burial");
        }
    }
}
