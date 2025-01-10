using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using AspNetCoreHero.ToastNotification.Abstractions;


namespace Admin.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MongoClient _client;
    private readonly INotyfService _toastNotification;

    private readonly IHttpClientFactory _httpFactory;



    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpFactory, INotyfService toastNotification)
    {
        _logger = logger;
        _client = new MongoClient(DotNetEnv.Env.GetString("MongoDB_Key"));
        _httpFactory = httpFactory;
        _toastNotification = toastNotification;
    }


    [HttpGet]
    public async Task <IActionResult> Home(){
      //var token = HttpContext.Session.GetString("token");
      //if(!string.IsNullOrEmpty(token)){
        try {
          FilterDefinition<AllEmployeeModel> filter = Builders<AllEmployeeModel>.Filter.Ne("Nome","test");
          var employeeDb = _client.GetDatabase("fabio").GetCollection<AllEmployeeModel>("Employee");
          var allEmployee = await employeeDb.Find(filter).ToListAsync();
          ViewBag.All = allEmployee;
          return View(allEmployee);
        } catch (Exception e) {
          _logger.LogInformation(e.Message);
          ModelState.AddModelError(string.Empty, e.Message);
        }
        return View();
      //}
      //return RedirectToRoute("default");
    }

    [HttpPost("ToBadge")]
    public async Task <IActionResult> ToBadge(ObjectId id){
      try {
        FilterDefinition<AllEmployeeModel> filter = Builders<AllEmployeeModel>.Filter.Eq("_id", id);
        var employeeDb = _client.GetDatabase("fabio").GetCollection<AllEmployeeModel>("Employee");
        var employeeSearch = employeeDb.Find(filter).ToList();
        var httpClient = _httpFactory.CreateClient();
        var employee = new Dictionary<string, string>
        {
          { "id", id.ToString() },
          { "ruolo", employeeSearch[0].Ruolo }
        };
        var json = new StringContent(
          JsonSerializer.Serialize(employee),
          Encoding.UTF8,
          Application.Json
        );
        var resposne = await httpClient.PostAsync(DotNetEnv.Env.GetString("Raspberry_IP"), json);
        if(resposne.IsSuccessStatusCode){
          _toastNotification.Success("Dati scritti su badge");
        }
        return RedirectToAction("Home", "Home");
      } catch (Exception e){
        _toastNotification.Error("Errore, ritenta");
        ModelState.AddModelError(string.Empty, e.Message);
        return RedirectToAction("Home", "Home");
      }
    }


    [HttpPost("Delete")]
    public async Task <IActionResult> Delete(ObjectId id){      
        try{
          FilterDefinition<AllEmployeeModel> filter = Builders<AllEmployeeModel>.Filter.Eq("_id", id);
          var employeeDb = _client.GetDatabase("fabio").GetCollection<AllEmployeeModel>("Employee");
          var toDelete = await employeeDb.DeleteOneAsync(filter);
          if(toDelete.DeletedCount == 1){
            _toastNotification.Success("Cncellazione avvenuta");
          }
        } catch (Exception e) {
          _toastNotification.Error("Errore, riprovare");
          ModelState.AddModelError(string.Empty, e.Message);
        }
        return RedirectToAction("Home", "Home");
    }

    [HttpGet("Logout")]
    public IActionResult Logout(){
      HttpContext.Session.Clear();
      _logger.LogInformation("pppp");
      return RedirectToRoute("default");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
