using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atcco.Data;
using Atcco.Constants;
using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Atcco.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;





        private readonly IWebHostEnvironment _webHostEnvironment;



        public ProjectsController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {

            List<Project> myList = await _context.Projects.ToListAsync();

            foreach (var project in myList)
            {
                project.Images = await _context.ImagePaths.Where(x => x.ProjectId == project.ProjectId).ToListAsync();

            }



            return _context.Projects != null ?
                    View(myList) :
                    Problem("Entity set 'ApplicationDbContext.Projects'  is null.");

            //	return RedirectToAction("404", "Index");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,PublishDate,Location,category")] Project project, List<IFormFile> files)
        {
            project.Images = new List<ImagePath>();

            var _uploadFolderPath = FileUploadConstants.UploadFolderPath;
            if (files != null && files.Count > 0)
            {
                foreach (var item in files)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(item.FileName);
                    var filePath = Path.Combine(_uploadFolderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    ImagePath imagePath = new ImagePath();
                    imagePath.imagePath = fileName;

                    project.Images.Add(imagePath);
                }



            }


            //if (ModelState.IsValid)
            //{





            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}

            //return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,PublishDate,Location,category")] Project project, List<IFormFile> files)
        {



            project.Images = new List<ImagePath>();

            var _uploadFolderPath = FileUploadConstants.UploadFolderPath;
            if (files != null && files.Count > 0)
            {
                foreach (var item in files)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(item.FileName);
                    var filePath = Path.Combine(_uploadFolderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    ImagePath imagePath = new ImagePath();
                    imagePath.imagePath = fileName;

                    project.Images.Add(imagePath);
                }




                _context.Update(project);

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);


            if (project == null)
            {
                return NotFound();
            }

            project.Images = _context.ImagePaths.Where(x => x.ProjectId == project.ProjectId).ToList();

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
