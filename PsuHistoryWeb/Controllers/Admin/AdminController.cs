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
            //RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            var rootpath = _env.WebRootPath;
            var report = new WebReport();
            //report.Report.Dictionary.Connections[0].ConnectionString = "Data Source=DESKTOP-PHD804P;AttachDbFilename=;Initial Catalog=app.db;Integrated Security=True;Persist Security Info=False;User ID=;Password=";
            report.Report.Load(rootpath + "/Files/save/report/Untitled.frx");

            var data = new DataSet();
            data.ReadXml(rootpath + "/Files/save/report/nwind.xml");
            report.Report.RegisterData(data, "NorthWind");
            //report.
            ViewBag.WebReport = report;
            return View();
        }
    }
}
