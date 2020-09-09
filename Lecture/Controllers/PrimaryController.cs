using System.Collections.Generic;
using System.Linq;
using Lecture.DAO;
using Lecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture.Controllers
{
    public class Primary : Controller
    {
        // ref to db
        private readonly LectureDbContext _context;
        public Primary(LectureDbContext context)
        {
            _context = context;
        }
        // landing page
        public IActionResult Index()
        {
            return View();
        }
        // view all writer
        public IActionResult ViewAll()
        {
            return View(_context);
        }
        // view writer by ID
        public IActionResult ViewOne(int writerID)
        {
            WriterModel foundWriter = _context.writers.FirstOrDefault(writer => writer.id == writerID);
            if(foundWriter != null)
            {
                return View(foundWriter);
            } else 
            {
                ViewData["error"] = "No writer found";
                return View("Error");
            }
        }
        // add writer to db
        [HttpPost]
        public IActionResult AddWriter(WriterModel newWriter)
        {
            _context.writers.Add(newWriter);
            _context.SaveChanges();
            return Content($"Added {newWriter.id}");
        }
        // update writer in db by ID
        [HttpPut]
        public IActionResult UpdateWriter()
        {
            return Content($"Update");
        }
        // delete writer in db by ID
        [HttpDelete]
        public IActionResult DeleteWriter()
        {
            return Content($"Delete");
        }
    }
}
