using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DanfossTestApplication.Models;
using DanfossTestApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace DanfossTestApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestApplicationDataContext _context;

        public HomeController(ILogger<HomeController> logger, TestApplicationDataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Equipment> equipments = _context.Equipments.ToList();
            return View(equipments);
        }
        public IActionResult List()
        {
            List<Equipment> equipments = _context.Equipments.ToList();
            return PartialView("List",equipments);
        }
        [HttpPost]
        public JsonResult Save(Equipment EF)
        {
            bool data = false;
            string mess = "";
            try
            {
                _context.Equipments.Add(EF);
                _context.SaveChanges();
                data = true;
                mess = "Запись успешно добавлена.";
            }
            catch(Exception ex)
            {
                mess = "Во время добавления произошла ошибка";
            }
            var result = new[] { new { data, mess } };
            return Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNote(int Id, string description, string url, string name)
        {
            try
            {
                Equipment eq = _context.Equipments.Find(Id);
                Note new_note = new Note();
                new_note.Description = description;
                new_note.Equipment = eq;
                _context.Notes.Add(new_note);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveLink(int Id, string url, string name)
        {
            try
            {
                Equipment eq = _context.Equipments.Find(Id);
                Link new_link = new Link();
                new_link.URL = url;
                new_link.Name = name;
                new_link.Equipment = eq;
                _context.Links.Add(new_link);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetInfo(int id)
        {
            Equipment currenteq = _context.Equipments.Include(n=>n.Notes).Include(l=>l.Links).First(e=>e.Id == id);
            return View("Info", currenteq);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
