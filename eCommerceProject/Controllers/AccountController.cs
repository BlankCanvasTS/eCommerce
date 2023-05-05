using Microsoft.AspNetCore.Mvc;
using eCommerceProject.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using eCommerceProject.Data;

namespace eCommerceProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly eCommerceProjectContext _context;

        public AccountController(eCommerceProjectContext context)
        {
            _context = context;
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
        // GET: /Account/CreateAccount/
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _context.CreateAccountModel.FirstOrDefault(u => u.username == username && u.password == password);

            // Compare the data with the "password" parameter and return the result
            if (user != null && user.password == password)
            {
                string transactionKey = TransactionKey.CreateTransactionKey(username, DateTime.Now);
                HttpContext.Session.SetString("TransactionKey", transactionKey);

                string savedTransactionKey = HttpContext.Session.GetString("TransactionKey");
                if (savedTransactionKey != transactionKey)
                {
                    ViewBag.Error = "Error saving transaction key to session";
                    return View();
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }
    }
}
