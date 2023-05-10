using eCommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using eCommerceProject.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly eCommerceProjectContext _context;
        public CheckoutController(eCommerceProjectContext context)
        {
            _context = context;
        }
        public IActionResult CheckoutPageB()
        {
            return View();
        }
        public IActionResult CheckoutPageS()
        {
            return View();
        }
        public IActionResult CheckoutPageG()
        {
            return View();
        }

        public IActionResult SuccessfulBronzeSub() 
        {
            return View();
        }
        public IActionResult SuccessfulSilverSub()
        {
            return View();
        }
        public IActionResult SuccessfulGoldSub()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CheckoutPageB(string cardNumber, string cardExpDate, string cardSecCode, int cardFunds, Boolean onHold)
        {
            var checkout = _context.CreateAccountModel.FirstOrDefault(u => u.cardNumber == cardNumber && 
                                                                  u.cardExpDate == cardExpDate && u.cardSecCode == cardSecCode);

            if (checkout != null) 
            {
                if (checkout.cardFunds >= 20 && checkout.onHold == false)
                {
                    return RedirectToAction("SuccessfulBronzeSub");
                }
                else if(checkout.cardFunds >= 20 && checkout.onHold == true)
                {
                    ViewBag.Error = "Transaction Failed, card is on hold.";
                    return View();
                }
                else if(checkout.cardFunds < 20 && checkout.onHold == false)
                {
                    ViewBag.Error = "Transaction Failed, not enough funds on card.";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Transaction Failed, not enough funds on card and card on hold.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Invalid cardNumber, cardExpDate, or cardSecCode";
                return View();
            }
        }

        [HttpPost]
        public ActionResult CheckoutPageS(string cardNumber, string cardExpDate, string cardSecCode, int cardFunds, Boolean onHold)
        {
            var checkout = _context.CreateAccountModel.FirstOrDefault(u => u.cardNumber == cardNumber &&
                                                                  u.cardExpDate == cardExpDate && u.cardSecCode == cardSecCode);
            if (checkout != null)
            {
                if (checkout.cardFunds >= 25 && checkout.onHold == false)
                {
                    return RedirectToAction("SuccessfulSilverSub");
                }
                else if (checkout.cardFunds >= 25 && checkout.onHold == true)
                {
                    ViewBag.Error = "Transaction Failed, card is on hold.";
                    return View();
                }
                else if (checkout.cardFunds < 25 && checkout.onHold == false)
                {
                    ViewBag.Error = "Transaction Failed, not enough funds on card.";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Transaction Failed, not enough funds on card and card on hold.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Invalid cardNumber, cardExpDate, or cardSecCode";
                return View();
            }
        }

        [HttpPost]
        public ActionResult CheckoutPageG(string cardNumber, string cardExpDate, string cardSecCode, int cardFunds, Boolean onHold)
        {
            var checkout = _context.CreateAccountModel.FirstOrDefault(u => u.cardNumber == cardNumber &&
                                                                  u.cardExpDate == cardExpDate && u.cardSecCode == cardSecCode);
            if (checkout != null)
            {
                if (checkout.cardFunds >= 30 && checkout.onHold == false)
                {
                    return RedirectToAction("SuccessfulGoldSub");
                }
                else if (checkout.cardFunds >= 30 && checkout.onHold == true)
                {
                    ViewBag.Error = "Transaction Failed, card is on hold.";
                    return View();
                }
                else if (checkout.cardFunds < 30 && checkout.onHold == false)
                {
                    ViewBag.Error = "Transaction Failed, not enough funds on card.";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Transaction Failed, not enough funds on card and card on hold.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Invalid cardNumber, cardExpDate, or cardSecCode";
                return View();
            }
        }

    }
}
