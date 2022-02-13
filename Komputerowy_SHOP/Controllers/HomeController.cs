using Komputerowy_SHOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Komputerowy_SHOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //jako kto zalogowany
        public IActionResult Guest()
        {
            GlobalVar.GlobalUserType = 0;
            return View("Views/Home/Index.cshtml");
        }
        public IActionResult Admin()
        {
            GlobalVar.GlobalUserType = 1;
            return View("Views/Home/Index.cshtml");
        }
        public IActionResult Userek()
        {
            GlobalVar.GlobalUserType = 2;
            GlobalVar.GlobalUserName = "apor";
            GlobalVar.GlobalUserId = 9;
            return View("Views/Home/Index.cshtml");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
