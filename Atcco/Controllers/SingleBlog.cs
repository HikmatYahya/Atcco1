using Atcco.Data;
using Atcco.Models.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atcco.Controllers
{
    public class SingleBlog : Controller
    {
		private readonly ApplicationDbContext _context;


		public SingleBlog(ApplicationDbContext context)
		{

			_context = context;
		}
		// GET: SingleBlog
		public async Task<IActionResult> Index(int? id, Category? category)
		{

			// Retrieve the object with the known ID
			var targetObject = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == id);
			targetObject.Images = await _context.ImagePaths.Where(x => x.ProjectId == targetObject.ProjectId).ToListAsync(); ;

			// Retrieve the last three objects with the desired category
			var lastThreeWithCategory = _context.Projects
				.Where(modelItem => modelItem.category == category) // Replace with your desired enum value
				.OrderByDescending(modelItem => modelItem.PublishDate) // Assuming you have a date property for ordering
				.Take(3) // Take the last three items
				.ToList();


			foreach (var project in lastThreeWithCategory)
			{
				project.Images = await _context.ImagePaths.Where(x => x.ProjectId == project.ProjectId).ToListAsync();

			}

			// Combine the results into a view model or data structure as needed
			var viewModel = new ObjWithList
			{
				TargetObject = targetObject,
				LastThreeWithCategory = lastThreeWithCategory
			};

			return View(viewModel);
		}

        // GET: SingleBlog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SingleBlog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SingleBlog/Create
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

        // GET: SingleBlog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SingleBlog/Edit/5
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

        // GET: SingleBlog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SingleBlog/Delete/5
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
