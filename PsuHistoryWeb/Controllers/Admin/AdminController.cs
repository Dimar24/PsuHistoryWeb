using FastReport.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PsuHistoryWeb.Domain.Entities.Users;
using PsuHistoryWeb.Models;
using PsuHistoryWeb.Service.Interfaces;
using System.Data;
using System;
using FastReport.Utils;

namespace PsuHistoryWeb.Controllers.Admin
{
    [Route("admin")]
    [ApiController]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserService _service;
        [Obsolete]
        private readonly IHostingEnvironment _env;

        [Obsolete]
        public AdminController(IUserService service, IHostingEnvironment env)
        {
            _service = service;
            _env = env;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("report")]
        [Obsolete]
        public IActionResult Report()
        {
            var rootpath = _env.WebRootPath;
            var report = new WebReport();
            var data = new DataSet();
            data.ReadXml(rootpath + "/Files/save/report/nwind.xml");
            report.Report.Load(rootpath + "/Files/save/report/Simple List.frx");
            report.Report.RegisterData(data);

            ViewBag.WebReport = report;
            return View();
        }
    }
}
