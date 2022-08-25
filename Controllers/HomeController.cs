using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solsr.domains;
using Solsr.Models;
using System.Diagnostics;

namespace Solsr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDB _context;

        public HomeController(ILogger<HomeController> logger, AppDB context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return _context.Persons != null ?
                        View(await _context.Persons.Where(x =>
                            x.BirthDate.DayOfYear >= DateTime.Now.DayOfYear &&
                            x.BirthDate.DayOfYear < DateTime.Now.DayOfYear + 14).ToListAsync()) :
                        Problem("Entity set 'AppDB.Persons'  is null.");
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}