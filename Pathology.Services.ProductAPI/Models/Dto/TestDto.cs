namespace Mango.Services.TestAPI.Models.Dto
{
	public class TestDto
	{
		public int TestId { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public string CategoryName { get; set; }
		public string? ImageUrl { get; set; }
		public string? ImageLocalPath { get; set; }
		public IFormFile? Image { get; set; }
	}
}
