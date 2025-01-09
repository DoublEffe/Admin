using System.Net;
using System.Text.Json;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Cookies;


using DotNetEnv;


//provare page invece di view in authorizepage
//provare il reindirizzamento ad auth se token esiste altrimenti non-auth nel middleware, vdere se il reindirizzamento funziona sempre
var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
// Add auth schema
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => {
  
  options.LoginPath = "/";
  options.AccessDeniedPath = "/Auth";
  options.Authority = $"https://securetoken.google.com/" + DotNetEnv.Env.GetString("Firebase_ID");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"https://securetoken.google.com/"  + DotNetEnv.Env.GetString("Firebase_ID"),
            ValidateAudience = true,
            ValidAudience =  DotNetEnv.Env.GetString("Firebase_ID"),
            ValidateLifetime = true
        };
});*/

builder.Services.AddHttpClient();

builder.Services.AddRazorPages(options =>
{
    //options.RootDirectory = "/Pages";
    options.Conventions.AuthorizePage("/Auth");
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add firebase configuration
builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
  {
    ApiKey = DotNetEnv.Env.GetString("Firebase_Api_Key") ,
    AuthDomain = DotNetEnv.Env.GetString("Firebase_ID") + ".firebaseapp.com",
    Providers =
      [
        // Add and configure individual providers
        new EmailProvider()
      ],
  }
));

builder.Services.AddSession(options => {
  options.IdleTimeout = TimeSpan.FromSeconds(20);
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
});

builder.Services.AddNotyf(config=> { config.DurationInSeconds = 10;config.IsDismissable = true;config.Position = NotyfPosition.BottomRight; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
/*app.Use(async (context, next) =>
{
    var token = context.Session.GetString("token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Response.Redirect("/Home");
        return;
        
    }
    else{
        context.Response.Redirect("/");
        
    }
    
   
    await next();
});*/

app.UseStatusCodePages(contextAccessor =>
{
  var response = contextAccessor.HttpContext.Response;
  var home = contextAccessor.HttpContext.GetRouteValue;
  
  app.Logger.LogInformation(Convert.ToString(response.StatusCode));
  //app.Logger.LogInformation(JsonSerializer.Serialize(contextAccessor.HttpContext.Request.Headers));
  if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
  {
    response.Redirect("/not-auth");
  }
  

  return Task.CompletedTask;
});
app.MapRazorPages();
//app.UseHttpsRedirection();
app.UseRouting();
app.UseNotyf();
app.UseAuthorization();
app.UseAuthentication();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "/",
    defaults: new {controller = "FirebaseAuth", action = "Login"})
    .WithStaticAssets();

app.MapControllerRoute(
    name: "signup",
    pattern: "SignUp",
    defaults: new {controller = "FirebaseAuth", action = "SignUp"})
    .WithStaticAssets();

app.MapControllerRoute(
    name: "Home",
    pattern: "/Home",
    defaults: new {controller = "Home", action = "Home"})
    .WithStaticAssets();

app.MapControllerRoute(
    name: "Add",
    pattern: "/Add",
    defaults: new {controller = "AddEmployee", action = "Add"})
    .WithStaticAssets();

app.MapControllerRoute(
    name: "Update",
    pattern: "/Update/{id?}",
    defaults: new {controller = "UpdateEmployee", action = "Update"})
    .WithStaticAssets();
/*app.MapControllerRoute(
    name: "def",
    pattern: "{controller=Home}/{action=Index}");*/


app.Run();
