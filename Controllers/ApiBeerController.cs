using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiBeerController : ControllerBase
	{
		private readonly CervezasDbContext _context;

		public ApiBeerController(CervezasDbContext cervezasDbContext)
		{
			_context = cervezasDbContext;
		}
		[HttpGet("GetBeers")]
		public async Task<List<Beer>> Get()
		=> await _context.Beers.ToListAsync();

		[HttpPost("PostBeers")]
		public async Task<IActionResult> Post(Beer newBeer)
		{
			_context.Beers.Add(newBeer);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(Get), new { id = newBeer.BeerId }, newBeer);
		}

	}


}
