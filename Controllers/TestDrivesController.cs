using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoGaragemIdentity.Data;
using ProjetoGaragemIdentity.Models;

namespace ProjetoGaragemIdentity.Controllers
{
    [Authorize]
    public class TestDrivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestDrivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestDrives
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestDrive.ToListAsync());
            return View(await _context.TestDrive.Include(c => c.Carro).ToListAsync());
            return View(await _context.TestDrive.Include(c => c.Funcionario).ToListAsync());
            return View(await _context.TestDrive.Include(c => c.Cliente).ToListAsync());
            
        }

        // GET: TestDrives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testDrive == null)
            {
                return NotFound();
            }

            return View(testDrive);
        }

        // GET: TestDrives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestDrives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataRetirada,DataDevolucao,Id,Descricao")] TestDrive testDrive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testDrive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testDrive);
        }

        // GET: TestDrives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive.FindAsync(id);
            if (testDrive == null)
            {
                return NotFound();
            }
            return View(testDrive);
        }

        // POST: TestDrives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataRetirada,DataDevolucao,Id,Descricao")] TestDrive testDrive)
        {
            if (id != testDrive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testDrive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDriveExists(testDrive.Id))
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
            return View(testDrive);
        }

        // GET: TestDrives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testDrive == null)
            {
                return NotFound();
            }

            return View(testDrive);
        }

        // POST: TestDrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testDrive = await _context.TestDrive.FindAsync(id);
            _context.TestDrive.Remove(testDrive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestDriveExists(int id)
        {
            return _context.TestDrive.Any(e => e.Id == id);
        }
    }
}
