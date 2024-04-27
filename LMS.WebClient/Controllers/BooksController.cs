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
    public class BooksController : Controller
    {

        public BooksController()
        {
            
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Books.ToListAsync());
            return View();
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);*/
            return View();
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,ISBN,AuthorID,PublishedDate,AvailableCopies,TotalCopies")] Books books)
        {
            /*if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(books);*/
            return View();
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /* if (id == null)
             {
                 return NotFound();
             }

             var books = await _context.Books.FindAsync(id);
             if (books == null)
             {
                 return NotFound();
             }
             return View(books);*/
            return View();

        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Title,ISBN,AuthorID,PublishedDate,AvailableCopies,TotalCopies")] Books books)
        {
            /*if (id != books.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.BookID))
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
            return View(books);*/

            return View();
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);*/
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var books = await _context.Books.FindAsync(id);
            if (books != null)
            {
                _context.Books.Remove(books);
            }

            await _context.SaveChangesAsync();*/
            return RedirectToAction(nameof(Index));
        }

        /*private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }*/
    }
}
