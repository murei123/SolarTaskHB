using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solsr.domains;
using Solsr.domains.Entities;
using Solsr.Models;

namespace Solsr.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDB _context;

        public PersonController(AppDB context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index(SortState sort = SortState.NameAsc)
        {

            
            var users = sort switch
            {
                SortState.NameDesc => _context.Persons.OrderByDescending(s => s.Name),
                SortState.NameAsc => _context.Persons.OrderBy(s => s.Name),
                SortState.DateAsc => _context.Persons.OrderBy(s => s.BirthDate),
                SortState.DateDesc => _context.Persons.OrderByDescending(s => s.BirthDate),
                
                _ => _context.Persons.OrderBy(s => s.Name),
            };

            return View(await users.ToListAsync());
                        
        }

       

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LastName,FatherName,BirthDate,Picture")] AddPerson addPerson)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = addPerson.Name,
                LastName = addPerson.LastName,
                FatherName = addPerson.FatherName,
                BirthDate = addPerson.BirthDate,
            };
            if (ModelState.IsValid)
            {
               
                if(addPerson.Picture != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        addPerson.Picture.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        person.Picture = fileBytes;
                    }
                }
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,LastName,FatherName,BirthDate,Picture")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'AppDB.Persons'  is null.");
            }
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(Guid id)
        {
            return (_context.Persons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
