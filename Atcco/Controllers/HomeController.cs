using Atcco.Data;
using Atcco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Atcco.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;


		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;

			_context = context;
		}
		public async Task<IActionResult> Index()
		{


			//.OrderByDescending(modelItem => modelItem.PublishDate) // Assuming you have a date property for ordering
			//.Take(3)

			List<Project> myList = await _context.Projects.OrderByDescending(modelItem => modelItem.PublishDate).Take(3).ToListAsync();

			foreach (var project in myList)
			{
				project.Images = await _context.ImagePaths.Where(x => x.ProjectId == project.ProjectId).ToListAsync();

			}

			return View(myList);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}