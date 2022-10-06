using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //IEnumerable<Order> orderList = _db.Orders;
            
            var orderList = _db.Orders.Include("car").ToList();
            orderList = _db.Orders.Include("student").ToList();

            return View(orderList);
            
        }
        public IActionResult Create()
        {
            ViewBag.student = GetStudents();
            ViewBag.car = GetCars();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            ViewBag.student = GetStudents();
            ViewBag.car = GetCars();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
       public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrder(int? id)
        {
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.Orders.Remove(obj);
                _db.SaveChanges();

            return RedirectToAction("Index");
            

        }
        private List<SelectListItem> GetCars()
        {
            var lstCars = new List<SelectListItem>();

            var maListe = (from p in _db.Cars
                           select new SelectListItem
                           {
                               Text = p.Brand,
                               Value = p.Car_Id.ToString()
                           }).ToList();
            foreach(var x in maListe)
            {
                lstCars.Add(x);
            }
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--Select Car--"
            };
            lstCars.Insert(0, defItem);
            return lstCars;
        }
        private List<SelectListItem> GetStudents()
        {
            var lstStudents = new List<SelectListItem>();

            var maListe = (from p in _db.Students
                           select new SelectListItem
                           {
                               Text = p.FirstName,
                               Value = p.Student_Id.ToString()
                           }).ToList();
            foreach (var x in maListe)
            {
                lstStudents.Add(x);
            }
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--Select Name--"
            };
            lstStudents.Insert(0, defItem);
            return lstStudents;
        }
    }
}
