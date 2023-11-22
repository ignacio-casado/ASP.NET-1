using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.view_models
{
	public class BeerViewModel
	{
		[Required]
		[Display(Name="Nombre")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "Marca")]
		public int BrandId { get; set; }
	}
}
