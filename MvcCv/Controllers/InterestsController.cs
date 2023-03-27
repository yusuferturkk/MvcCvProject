using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class InterestsController : Controller
    {
        
        InterestsRepository repository = new InterestsRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInterests()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInterests(TblInterests tblInterests)
        {
            repository.Add(tblInterests);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInterests(int id)
        {
            var value = repository.GetById(id);
            repository.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInterests(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInterests(TblInterests tblInterests)
        {
            var value = repository.GetById(tblInterests.Id);
            value.Description1 = tblInterests.Description1;
            value.Description2 = tblInterests.Description2;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}