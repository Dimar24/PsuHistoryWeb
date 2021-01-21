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
using PsuHistoryWeb.Domain.Entities.Histories;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;

namespace PsuHistoryWeb.Controllers.Admin
{
    [Route("admin/burial/form")]
    [ApiController]
    [Authorize]
    public class FormController : Controller
    {
        IUnitOfWork _database;
        IService<Form> _service;
        IWebHostEnvironment _appEnvironment;

        public FormController(IService<Form> service, IUnitOfWork database, IWebHostEnvironment appEnvironment)
        {
            _service = service;
            _database = database;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Burial()
        {
            var forms = await _service.GetAllAsync();
            return View("~/Views/Admin/Form/Index.cshtml", forms);
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("~/Views/Admin/Form/Add.cshtml");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] Form form, [FromForm] IFormFileCollection uploads)
        {
            if (!await _service.CreateAsync(form))
            {
                ModelState.AddModelError("", "Уже существует");

                return View("~/Views/Admin/Form/Add.cshtml", form);
            }

            var id = (await _service.FindAsync(form)).Id;
            string path = "/files/save/form/";

            foreach (var uploadedFile in uploads)
            {
                string fileName = Guid.NewGuid() + "." + uploadedFile.ContentType.Split("/")[1];

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path + fileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                    await _database.AttachmentForms.CreateAsync(new AttachmentForm() {
                        Path = path + fileName,
                        FileType = uploadedFile.ContentType.Split("/")[1],
                        FormId = id
                    });
                }
            }

            return RedirectToAction("Form");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var burial = await _service.GetAsync(id);

            ViewBag.Attachment = (await _database.AttachmentForms.GetAllAsync()).Where(a => a.FormId == id);

            return View("~/Views/Admin/Form/Edit.cshtml", burial);
        }

        [HttpPut("{id}")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] Form form, [FromForm] IFormFileCollection uploads, [FromRoute] int id)
        {
            form.Id = id;

            if (!await _service.UpdateAsync(form))
            {
                ModelState.AddModelError("", "Уже существует");

                ViewBag.Attachment = (await _database.AttachmentForms.GetAllAsync()).Where(a => a.FormId == id);

                return View("~/Views/Admin/Form/Edit.cshtml", form);
            }

            string path = "/files/save/form/";

            foreach (var uploadedFile in uploads)
            {
                string fileName = Guid.NewGuid() + "." + uploadedFile.ContentType.Split("/")[1];

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path + fileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                    await _database.AttachmentForms.CreateAsync(new AttachmentForm()
                    {
                        Path = path + fileName,
                        FileType = uploadedFile.ContentType.Split("/")[1],
                        FormId = id
                    });
                }
            }

            return RedirectToAction("Form");
        }


        [HttpGet]
        [Route("look/{id}")]
        public async Task<IActionResult> Look([FromRoute] int id)
        {
            var form = await _service.GetAsync(id);
            ViewBag.Attachment = (await _database.AttachmentForms.GetAllAsync()).Where(a => a.FormId == id);
            return View("~/Views/Admin/Form/Look.cshtml", form);
        }


        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Form");
        }
    }
}
