using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        
        GenericRepository<TblAdmin> repository = new GenericRepository<TblAdmin>();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(TblAdmin tblAdmin)
        {
            repository.Add(tblAdmin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = repository.GetById(id);
            repository.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmin tblAdmin)
        {
            var value = repository.GetById(tblAdmin.Id);
            value.Username = tblAdmin.Username;
            value.Password = tblAdmin.Password;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}