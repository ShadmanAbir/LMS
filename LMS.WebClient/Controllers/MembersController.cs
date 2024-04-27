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
    public class MembersController : Controller
    {
        

        public MembersController()
        {
            
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Members.ToListAsync());
            return View();
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .FirstOrDefaultAsync(m => m.MemberID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);*/
            return View();
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberID,FirstName,LastName,Email,PhoneNumber,RegistrationDate")] Members members)
        {
            /*if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);*/
            return View();
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /* if (id == null)
             {
                 return NotFound();
             }

             var members = await _context.Members.FindAsync(id);
             if (members == null)
             {
                 return NotFound();
             }
             return View(members);*/
            return View();
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberID,FirstName,LastName,Email,PhoneNumber,RegistrationDate")] Members members)
        {
            /*if (id != members.MemberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.MemberID))
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
            return View(members);*/
            return View();
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .FirstOrDefaultAsync(m => m.MemberID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);*/
            return View();
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var members = await _context.Members.FindAsync(id);
            if (members != null)
            {
                _context.Members.Remove(members);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            return View();
        }

        /*private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.MemberID == id);
        }*/
    }
}
