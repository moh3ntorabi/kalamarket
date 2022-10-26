using Application.Services.Visitors.GetTodayReport;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetTodayReportService getTodayReportService;

        public HomeController(IGetTodayReportService getTodayReportService)
        {
            this.getTodayReportService = getTodayReportService;
        }
        public IActionResult Index()
        {
            var reportDto = getTodayReportService.Execute();
            return View(reportDto);
        }
     


    }
}
