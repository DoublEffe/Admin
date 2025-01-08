using System.Diagnostics;
using Admin.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Admin.Controllers;


public class AddEmployeeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MongoClient _client;
    private readonly INotyfService _toastNotification;
    



    public AddEmployeeController(ILogger<HomeController> logger, INotyfService toastNotification)
    {
      _logger = logger;
      _client = new MongoClient("mongodb+srv://fabio:1234@cluster0.bg7sv.mongodb.net/admin?retryWrites=true&w=majority&appName=Cluster0");
      _toastNotification = toastNotification;
    }

    [HttpGet]
    public IActionResult Add(){
      return View();
    }

    [HttpPost("Add")]
    public async Task <IActionResult> Add(EmployeeModel employee){
      try{   
        var employeeDb = _client.GetDatabase("fabio").GetCollection<EmployeeModel>("Employee");
        await employeeDb.InsertOneAsync(new (){
          Nome =  employee.Nome, 
          Cognome = employee.Cognome, 
          Ruolo = employee.Ruolo
        });
        _toastNotification.Success("Impiegato aggiunto");
        return RedirectToRoute("admin");
      }
      catch (Exception ex){
        _toastNotification.Error("Errore. riprovare");
        ModelState.AddModelError(string.Empty, ex.Message);
        return RedirectToAction("Add", "AddEmployee");
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
