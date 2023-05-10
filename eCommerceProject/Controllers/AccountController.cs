using Microsoft.AspNetCore.Mvc;
using eCommerceProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using eCommerceProject.Data;

namespace eCommerceProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly Models.AuthenticationService _authenticationService;

        public AccountController(Models.AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

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

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = _authenticationService.AuthenticateUser(model.Username, model.password);
            return View(model);
        }
    }
}
