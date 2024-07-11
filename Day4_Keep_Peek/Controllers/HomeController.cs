using Day4_Keep_Peek.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day4_Keep_Peek.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["TempModel"] = "This is TempData Example";
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            // Store a message in TempData
            TempData["Message"] = "Form submitted successfully!";

            // Redirect to the Success action
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            // Retrieve the message from TempData
            TempData["Value"] = "This is a value stored in TempData for the next request.";
            return View();
        }
        public IActionResult PeekValue()
        {
            // Peek at the value in TempData so it is not deleted
            var value = TempData.Peek("Value");
            ViewBag.PeekedValue = value;
            return View();
        }

        public IActionResult ReadValue()
        {
            // Read the value from TempData, marking it for deletion
            var value = TempData["Value"];
            ViewBag.ReadValue = value;
            return View();
        }
        public IActionResult KeepValue()
        {
            // Read the value from TempData and decide to keep it for the next request
            var value = TempData["Value"];
            TempData.Keep("Value");
            ViewBag.KeptValue = value;
            return View();
        }

        public IActionResult ReadAndDeleteValue()
        {
            // Read the value from TempData, marking it for deletion
            var value = TempData["Value"];
            ViewBag.ReadValue = value;
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
