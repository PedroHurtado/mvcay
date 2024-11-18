using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;


namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static List<Foo> fooList = new List<Foo>(){
        new Foo{Name = "Pedro",Id=1},
        new Foo{Name = "David",Id=2},
    };

   
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
        return View(fooList);
    }

    public ActionResult Edit(int id){
        var foo = fooList.Where(f=>f.Id==id).FirstOrDefault();
        if (foo==null){
            return View("NotFound");
        }
        return View(foo);
    }
    [HttpPost]
    [ValidateAntiForgeryToken] 
    public ActionResult Edit(Foo foo){
        if(ModelState.IsValid){
            var index = fooList.FindIndex(f => f.Id==foo.Id);
            if(index>-1){
                fooList[index] = foo;
            }
            return RedirectToAction("List", "Home"); //PRG
        }
        return View(foo);
        
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
