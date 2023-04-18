using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCommerceProject.Data;
using eCommerceProject.Models;

namespace eCommerceProject.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly eCommerceProjectContext _context;

        public CreateAccountController(eCommerceProjectContext context)
        {
            _context = context;
        }

        // GET: CreateAccount
        public async Task<IActionResult> Index()
        {
              return _context.CreateAccountModel != null ? 
                          View(await _context.CreateAccountModel.ToListAsync()) :
                          Problem("Entity set 'eCommerceProjectContext.CreateAccountModel'  is null.");
        }

        // GET: CreateAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CreateAccountModel == null)
            {
                return NotFound();
            }

            var createAccountModel = await _context.CreateAccountModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (createAccountModel == null)
            {
                return NotFound();
            }

            return View(createAccountModel);
        }

        // GET: CreateAccount/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: CreateAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,username,password,nameFull,cardNumber,cardExpDate,cardSecCode,cardFunds,onHold")] CreateAccountModel createAccountModel)
        {


            if (ModelState.IsValid)
            {
                _context.Add(createAccountModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createAccountModel);
        }

        // GET: CreateAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CreateAccountModel == null)
            {
                return NotFound();
            }

            var createAccountModel = await _context.CreateAccountModel.FindAsync(id);
            if (createAccountModel == null)
            {
                return NotFound();
            }
            return View(createAccountModel);
        }

        // POST: CreateAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,username,password,nameFull,cardNumber,cardExpDate,cardSecCode,cardFunds,onHold")] CreateAccountModel createAccountModel)
        {
            if (id != createAccountModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(createAccountModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreateAccountModelExists(createAccountModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(createAccountModel);
        }

        // GET: CreateAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CreateAccountModel == null)
            {
                return NotFound();
            }

            var createAccountModel = await _context.CreateAccountModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (createAccountModel == null)
            {
                return NotFound();
            }

            return View(createAccountModel);
        }

        // POST: CreateAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CreateAccountModel == null)
            {
                return Problem("Entity set 'eCommerceProjectContext.CreateAccountModel'  is null.");
            }
            var createAccountModel = await _context.CreateAccountModel.FindAsync(id);
            if (createAccountModel != null)
            {
                _context.CreateAccountModel.Remove(createAccountModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreateAccountModelExists(int id)
        {
          return (_context.CreateAccountModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
