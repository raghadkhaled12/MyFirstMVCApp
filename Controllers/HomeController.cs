using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ConferenceName = "Tech Summit 2025";
        ViewBag.ConferenceDate = "June 15-17, 2025";
        ViewBag.ConferenceLocation = "San Francisco, CA";
        return View();
    }
    [HttpGet]
    public ActionResult Register()
    {
        ViewBag.Tracks = new List<SelectListItem>
            {
                new SelectListItem { Text = "Web Development", Value = "web" },
                new SelectListItem { Text = "Mobile Development", Value = "mobile" },
                new SelectListItem { Text = "Cloud Computing", Value = "cloud" },
                new SelectListItem { Text = "Data Science", Value = "data" },
                new SelectListItem { Text = "DevOps", Value = "devops" }
            };

        return View();
    }
    [HttpPost]
    public ActionResult Register(Registration registration)
    {
        if (ModelState.IsValid)
        {
            registration.ID = new Random().Next(1000, 9999); 
            registration.RegistrationDate = DateTime.Now;

            ViewBag.Registration = registration;

            return View("Confirmation", registration);
        }

        ViewBag.Tracks = new List<SelectListItem>
            {
                new SelectListItem { Text = "Web Development", Value = "web" },
                new SelectListItem { Text = "Mobile Development", Value = "mobile" },
                new SelectListItem { Text = "Cloud Computing", Value = "cloud" },
                new SelectListItem { Text = "Data Science", Value = "data" },
                new SelectListItem { Text = "DevOps", Value = "devops" }
            };

        return View(registration);

    }

         public ActionResult Confirmation()
         {
              var registration = ViewBag.Registration;
              if (registration == null)
              {
                  return RedirectToAction("Index");
              }

              return View(registration);
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
