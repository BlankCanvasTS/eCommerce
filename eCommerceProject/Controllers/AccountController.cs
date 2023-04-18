using Microsoft.AspNetCore.Mvc;
using eCommerceProject.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace eCommerceProject.Controllers
{
    public class AccountController : Controller
    {

        // GET: /Account/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /Account/Login/
        public IActionResult Login()
        {
            return View();
        }
        // GET: /Account/CreateAccount/
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Call a method in your authentication service to validate the user's credentials
                bool isAuthenticated = Models.AuthenticationService.AuthenticateUser(model.Username, model.Password);

                if (isAuthenticated)
                {
                    // Create an authentication token and save it in a cookie or session
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };
                    var identity = new ClaimsIdentity(claims, "login");
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(principal);

                    // Redirect the user to the home page or a protected area
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Show a popup message when login fails
                    TempData["LoginErrorMessage"] = "Invalid username or password";

                    // Return the view with the model to display the error message
                    return View("~/Views/Home/Login.cshtml", model);
                }
            }
            return View(model);
        }
    }
}
