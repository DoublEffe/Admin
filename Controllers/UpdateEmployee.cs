using System.Diagnostics;
using Admin.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Admin.Controllers;


public class UpdateEmployeeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MongoClient _client;
    private readonly INotyfService _toastNotification;





    public UpdateEmployeeController(ILogger<HomeController> logger, INotyfService toastNotification)
    {
      _logger = logger;
      _client = new MongoClient("mongodb+srv://fabio:1234@cluster0.bg7sv.mongodb.net/admin?retryWrites=true&w=majority&appName=Cluster0");
      _toastNotification = toastNotification;
    }

    [HttpGet]
    public async  Task <IActionResult> Update(ObjectId id){
      try{   
        FilterDefinition<AllEmployeeModel> filter = Builders<AllEmployeeModel>.Filter.Eq("_id", id);
        var employeeDb = _client.GetDatabase("fabio").GetCollection<AllEmployeeModel>("Employee");
        var employeeSearch = await employeeDb.Find(filter).ToListAsync();
        ViewData["Employee"] = new EmployeeModel (){
          Nome = employeeSearch[0].Nome,
          Cognome = employeeSearch[0].Cognome,
          Ruolo = employeeSearch[0].Ruolo,
        };
        ViewData["Id"] = id;
      }
      catch (Exception ex){
        _logger.LogInformation(ex.Message);
        ModelState.AddModelError(string.Empty, ex.Message);
      }
      return View();
    }
    
    [HttpPost("Update")]
    public async Task <IActionResult> Update(AllEmployeeModel employee, ObjectId id){
      try{   
        FilterDefinition<AllEmployeeModel> filter = Builders<AllEmployeeModel>.Filter.Eq("_id", id);
        var employeeDb = _client.GetDatabase("fabio").GetCollection<AllEmployeeModel>("Employee");
        var employeeSearch = await employeeDb.Find(filter).ToListAsync();
        employeeDb.ReplaceOne(filter, employee);       
        _toastNotification.Success("Aggiornamento riuscito");
        return RedirectToRoute("admin");

      }
      catch (Exception ex){
        _toastNotification.Error("Errore. riprova");
        ModelState.AddModelError(string.Empty, ex.Message);
        return RedirectToRoute("admin");
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
