using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.WebClient.Models;
using LMS.Domain.Models;

namespace LMS.WebClient.Controllers
{
    public class BorrowedBooksController : Controller
    {
        

        public BorrowedBooksController()
        {
            
        }

        // GET: BorrowedBooks
        public async Task<IActionResult> Index()
        {
            //return View(await _context.BorrowdBooks.ToListAsync());
            return View();
        }

        // GET: BorrowedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var borrowedBooks = await _context.BorrowdBooks
                .FirstOrDefaultAsync(m => m.BorrowID == id);
            if (borrowedBooks == null)
            {
                return NotFound();
            }

            return View(borrowedBooks);*/
            return View();
        }

        // GET: BorrowedBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BorrowedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowID,BorrowDate,ReturnDate,Status,MemberID,BookID")] BorrowedBooks borrowedBooks)
        {
            /*if (ModelState.IsValid)
            {
                _context.Add(borrowedBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(borrowedBooks);*/
            return View();
        }

        // GET: BorrowedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var borrowedBooks = await _context.BorrowdBooks.FindAsync(id);
            if (borrowedBooks == null)
            {
                return NotFound();
            }
            return View(borrowedBooks);*/
            return View();
        }

        // POST: BorrowedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowID,BorrowDate,ReturnDate,Status,MemberID,BookID")] BorrowedBooks borrowedBooks)
        {
            /*if (id != borrowedBooks.BorrowID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowedBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowedBooksExists(borrowedBooks.BorrowID))
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
            return View(borrowedBooks);*/

            return View();
        }

        // GET: BorrowedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var borrowedBooks = await _context.BorrowdBooks
                .FirstOrDefaultAsync(m => m.BorrowID == id);
            if (borrowedBooks == null)
            {
                return NotFound();
            }

            return View(borrowedBooks);*/

            return View();
        }

        // POST: BorrowedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var borrowedBooks = await _context.BorrowdBooks.FindAsync(id);
            if (borrowedBooks != null)
            {
                _context.BorrowdBooks.Remove(borrowedBooks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            return View();
        }

        /*private bool BorrowedBooksExists(int id)
        {
            return _context.BorrowdBooks.Any(e => e.BorrowID == id);
        }*/
    }
}
