using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.view_models;

namespace WebApplication1.Controllers
{
	public class BeerController : Controller
	{
		private readonly CervezasDbContext _context;
		public BeerController(CervezasDbContext context)
		{
			_context = context;
		}
		public async Task <IActionResult> Index()
		{
			var beers = _context.Beers.Include(b=>b.Brand);
			return View(await beers.ToListAsync());
		}
		public IActionResult Create()
		{
			ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
			return View();	
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task <IActionResult> Create(BeerViewModel beerViewModel)
		{
			if (ModelState.IsValid)
			{
				var beer = new Beer()
				{
					Name = beerViewModel.Name,
					BrandId = beerViewModel.BrandId,
				};
				_context.Add(beer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", beerViewModel.BrandId);
			return View(beerViewModel);
		}
	}
}
