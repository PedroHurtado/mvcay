using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;


namespace mvc.Controllers;

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
        return View("Pepe");
    }

    public IActionResult About(){
        return View();
    }

    public IActionResult Foo(){
        Foo foo = new() { Id=1,Name="Pedro"};
        return View(foo);
    }

    public IActionResult List(){
        List<Foo> list =[
            new Foo { Id=1, Name="Pedro"},
            new Foo { Id=2, Name="Daniel"},
        ];
        return View(list);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int statusCode)    
    {
        if(statusCode == 404){
            return View("NotFound");
        }    
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
