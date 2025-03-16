
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace webapp.Controllers;



[ApiController]
[Route("[controller]")]

public class Configuration : ControllerBase


{
private  readonly  IConfiguration _configuration;

Configuration(IConfiguration  configuration)
{

    _configuration =  configuration;
}


[HttpGet("get-key")]  //static route 






// Page 101



}