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
using LMS.WebClient.Helper;

namespace LMS.WebClient.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly LMSHttpClient _httpClient;
        public AuthorsController(LMSHttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetAuthors());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            return View(await _httpClient.GetAuthorByID(id ?? 0));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorID,AuthorName,AuthorBio")] AuthorsViewModel authorVM)
        {
            await _httpClient.PostAuthorAsync(authorVM);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View(await _httpClient.GetAuthorByID(id ?? 0));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("AuthorID,AuthorName,AuthorBio")] AuthorsViewModel authorVM)
        {
            await _httpClient.PuttAuthorAsync(authorVM);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _httpClient.GetAuthorByID(id ?? 0);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authors = await _httpClient.GetAuthorByID(id);
            if (authors != null)
            {
                await _httpClient.DeleteAuthorAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
