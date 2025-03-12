using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webapp.Entities;
using webapp.Models;

// using System.ComponentModel.DataAnnotations;

using System;
namespace webapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;


    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Setstring()
    {
        EntityOne enone = new EntityOne();


        enone = null;
        // {
        //     Name = "prashanth",
        //     Email = "pashireddi@gmail.com",
        //     Phone = "816 203 9740",
        //     WillAttend = false
        // };
        return View(enone);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



}
