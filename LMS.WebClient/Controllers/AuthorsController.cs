using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.WebClient.Models;
using LMS.Domain.Models;
using Newtonsoft.Json;
using LMS.Core.ViewModels;

namespace LMS.WebClient.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly HttpClient _httpClient;
        public AuthorsController(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var apiUrl = "https://localhost:7080/api/Author";

            // Send GET request to the API endpoint
            var response = await _httpClient.GetAsync(apiUrl);

            // Check if the response is successful
            response.EnsureSuccessStatusCode();

            // Read response content as string
            var responseData = await response.Content.ReadAsStringAsync();
            var myApiData = JsonConvert.DeserializeObject<AuthorsViewModel>(responseData);
            return View();
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (authors == null)
            {
                return NotFound();
            }

            return View(authors);*/
            return View();
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorID,AuthorName,AuthorBio")] Authors authors)
        {
            /*            if (ModelState.IsValid)
                        {
                            _context.Add(authors);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        return View(authors);*/
            return View();
            
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /*            if (id == null)
                        {
                            return NotFound();
                        }

                        var authors = await _context.Authors.FindAsync(id);
                        if (authors == null)
                        {
                            return NotFound();
                        }
                        return View(authors);*/
            return View();
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorID,AuthorName,AuthorBio")] Authors authors)
        {
            /*if (id != authors.AuthorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorsExists(authors.AuthorID))
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
            return View(authors);*/
            return View();
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (authors == null)
            {
                return NotFound();
            }

            return View(authors);*/
            return View();
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var authors = await _context.Authors.FindAsync(id);
            if (authors != null)
            {
                _context.Authors.Remove(authors);
            }

            await _context.SaveChangesAsync();*/
            return RedirectToAction(nameof(Index));
        }

        /*private bool AuthorsExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorID == id);
        }*/
    }
}
