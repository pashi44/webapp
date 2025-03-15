using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;

// using System.ComponentModel.DataAnnotations;

using System;
namespace webapp.Controllers;

[ApiController]
[Route("/Home/GetObjects")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;


    }
[Route("/")]

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


[Route("/Home/Setstring")]
[HttpGet] 
   public IActionResult Setstring()
    {
        Post enone = new Post

        {
            Name = "prashanth",
            Phone = "816 203 9740",
            Email = "pashireddi@gmail.com",
            WillAttend = false
        };
        return View(enone);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }






}
