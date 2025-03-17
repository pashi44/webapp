
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace webapp.Controllers;



[ApiController]
[Route("[controller]")]

public class Configuration : ControllerBase


{
    private readonly IConfiguration _configuration;
    private readonly ILogger<Configuration> _logconfig;

    public Configuration(IConfiguration configuration, ILogger<Configuration> logconfig)
    {

        _configuration = configuration;
        _logconfig = logconfig;
    }


    [HttpGet("get-key")]  //static route 

    public ActionResult GetMyKey()
    {
        var myKey = _configuration["MyKey"];//from the appSettings.json
        return Ok(myKey);
    }

    [HttpGet("get-databasekey")]


    public ActionResult GetDBdeatils()
    {

        var key = _configuration["Database:ConnectionString"] ?? string.Empty;
        _logconfig.LogInformation(
              "This is a logging message with args: Today is { Week }. It is { Time }.",
               DateTime.Now.DayOfWeek, DateTime.Now.ToLongTimeString());

        return Ok(key);

    }





}