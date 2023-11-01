using Atcco.Data;
using Atcco.Models.Projects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atcco.Controllers
{
	public class BlogGridController : Controller
	{

		private readonly ApplicationDbContext _context;


		public BlogGridController(ApplicationDbContext context)
		{

			_context = context;
		}
		// GET: BlogGridController
		public async Task<IActionResult> Index(Category? category)
		{

			if (category == null)
			{

				List<Project> myList = await _context.Projects.ToListAsync();

				foreach (var project in myList)
				{
					project.Images = _context.ImagePaths.Where(x => x.ProjectId == project.ProjectId).ToList();

				}
				return _context.Projects != null ?
					  View(myList) :
					  Problem("Entity set 'ApplicationDbContext.Projects'  is null.");
			}
			else
			{

				List<Project> myList = await _context.Projects.Where(modelItem => modelItem.category == category).ToListAsync();

				foreach (var project in myList)
				{
					project.Images = _context.ImagePaths.Where(x => x.ProjectId == project.ProjectId).ToList();

				}



				return _context.Projects != null ?
							View(myList) :
							Problem("Entity set 'ApplicationDbContext.Projects'  is null.");

			}
		}


		// GET: Projects/Details/5



		// GET: BlogGridController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BlogGridController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BlogGridController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BlogGridController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: BlogGridController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BlogGridController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: BlogGridController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
