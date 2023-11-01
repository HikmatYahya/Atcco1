using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atcco.Controllers
{
	public class OurProjects : Controller
	{
		// GET: OurProjects
		public ActionResult Index()
		{
			return View();
		}

		// GET: OurProjects/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: OurProjects/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: OurProjects/Create
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

		// GET: OurProjects/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: OurProjects/Edit/5
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

		// GET: OurProjects/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: OurProjects/Delete/5
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
