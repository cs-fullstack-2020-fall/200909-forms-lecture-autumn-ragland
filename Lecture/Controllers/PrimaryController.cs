using System.Collections.Generic;
using System.Linq;
using Lecture.DAO;
using Lecture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            if(ModelState.IsValid)
            {
                _context.writers.Add(newWriter);
                _context.SaveChanges();
                // return Content($"Added {newWriter.id}");
                return RedirectToAction("ViewAll", "Primary");                
            } else 
            {
                string displayErr = "";
                List<string> errors = GetErrorListFromModelState(ModelState);
                errors.ForEach(err => displayErr += $" {err} ");
                ViewData["errors"] = displayErr;
                return View("WriterForm", newWriter);
            }

        }
        public IActionResult WriterForm()
        {
            return View();
        }
        // update writer in db by ID
        [HttpPost]
        public IActionResult UpdateWriter(WriterModel updateWriter)
        {
            WriterModel foundWriter = _context.writers.FirstOrDefault(writer => writer.id == updateWriter.id);
            if(ModelState.IsValid)
            {
                foundWriter.fName = updateWriter.fName;
                foundWriter.lName = updateWriter.lName;
                foundWriter.age = updateWriter.age;
                foundWriter.isPublished = updateWriter.isPublished;
                _context.SaveChanges();
                // return Content($"Update");   
                return RedirectToAction("ViewAll", "Primary");        
            } else
            {
                string displayErr = "";
                List<string> errors = GetErrorListFromModelState(ModelState);
                errors.ForEach(err => displayErr += $" {err} ");
                ViewData["errors"] = displayErr;
                return View("EditForm", updateWriter);               
            }

        }
        public IActionResult EditForm(int id)
        {
            WriterModel foundWriter = _context.writers.FirstOrDefault(writer => writer.id == id);
            if(foundWriter != null)
            {
                return View(foundWriter);
            } else
            {
                ViewData["error"] = "No writer found";
                return View("Error");
            }
        }
        // delete writer in db by ID
        [HttpGet]
        public IActionResult DeleteWriter(int writerID)
        {
            WriterModel foundWriter = _context.writers.FirstOrDefault(writer => writer.id == writerID);
            if(foundWriter != null)
            {
                _context.Remove(foundWriter);
                _context.SaveChanges();
                // return Content($"Delete");   
                return RedirectToAction("ViewAll", "Primary");
            } else
            {
                ViewData["error"] = "No writer found to delete";
                return View("Error");
            }
        }
        // method to capture model state validation errors
        public static List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            IEnumerable<string> query = from state in modelState.Values
                from error in state.Errors
                select error.ErrorMessage;

            List<string> errorList = query.ToList();
            return errorList;
        }
    }
}
