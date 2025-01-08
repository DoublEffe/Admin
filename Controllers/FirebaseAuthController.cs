
using System.Diagnostics;
using System.Security.Claims;
using Admin.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers;

public class FirebaseAuthController : Controller
{
    

    private readonly ILogger<FirebaseAuthController> _logger;
    private readonly FirebaseAuthClient _firebaseAuth;

    public FirebaseAuthController(ILogger<FirebaseAuthController> logger, FirebaseAuthClient firebaseAuth)
    {
        _logger = logger;
        _firebaseAuth = firebaseAuth;
        
    }

    public IActionResult Auth(){
      return View();
    }
   
    public async Task<IActionResult> SignUp(SignUpModel data)
    { 
        try{

          await _firebaseAuth.CreateUserWithEmailAndPasswordAsync(data.Email, data.Password);
          var userCredential = await _firebaseAuth.SignInWithEmailAndPasswordAsync(data.Email, data.Password);
          userCredential.AuthCredential.GetHashCode();
          var token = await userCredential.User.GetIdTokenAsync();
          HttpContext.Session.SetString("token", token);
          /*
          var cliams = new List<Claim>(){
            new Claim(ClaimTypes.Name, data.Email)
          };
          var cliamsIdentity = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme);
          await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(cliamsIdentity));*/
          return RedirectToRoute("Home");
        } catch( FirebaseAuthException e){
          ModelState.AddModelError(string.Empty, e.Message);
        } 

        return View();
    }
    [HttpGet]
    public IActionResult LogIn(){
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> LogIn(LoginModel data)
    { 
      try{
        var userCredentials = await _firebaseAuth.SignInWithEmailAndPasswordAsync(data.Email, data.Password);
        var token = await userCredentials.User.GetIdTokenAsync();
        HttpContext.Session.SetString("token", token);
        return RedirectToRoute("Home");
      } catch( FirebaseAuthException e){
        ModelState.AddModelError(string.Empty, e.Message);
      }
        
      return View();

    }
  
  

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}