using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExerciseOne.Data;
using ExerciseOne.Models;
using ExerciseOne.Web.Services;

namespace ExerciseOne.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IXMLService _xmlService;

        public UsersController(IXMLService xmlService)
        {
            _xmlService = xmlService;
        }

        // GET: Users
        public IActionResult Index()
        {
            var users = _xmlService.GetAllUsers().Result;
            return View(users);
        }

        // GET: Users/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _xmlService.GetUserById(id.Value.ToString()).Result;
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,CellPhone")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();

                await _xmlService.Create(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _xmlService.GetUserById(id.Value.ToString()).Result;
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Surname,CellPhone")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _xmlService.Update(user);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = await _context.User
            var user = await _xmlService.GetUserById(id.Value.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _xmlService.Delete(id.ToString());
            }
            catch(Exception ex)
            {

            }

            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            var user = _xmlService.GetUserById(id.ToString());

          return ((user == null)? false : true);
        }
    }
}
