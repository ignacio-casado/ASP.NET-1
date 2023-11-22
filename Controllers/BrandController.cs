using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BrandController : Controller
    {

        private readonly CervezasDbContext _context;

        public BrandController(CervezasDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }
    }
}
