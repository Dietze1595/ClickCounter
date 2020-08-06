using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcFaceitAPI.Models;

namespace MvcFaceitAPI.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SubscribeModel _client = new SubscribeModel();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SubscribeModel model)
        {
            int read = 0;
            using (StreamReader readtext = new StreamReader("write.txt"))
            {
                read = Int32.Parse(readtext.ReadLine());
            }
            ViewData["Counter"] = read;
            return View();
        }

        public IActionResult Subscribe(int btnSearch)
        {
            _client.ClickCount = btnSearch + 1;

            using (StreamWriter writetext = new StreamWriter("write.txt"))
            {
                writetext.WriteLine(_client.ClickCount);
            }

            ViewData["Counter"] = _client.ClickCount;
            return View("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
