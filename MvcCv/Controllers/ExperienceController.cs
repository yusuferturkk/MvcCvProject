using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        
        ExperienceRepository repository = new ExperienceRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience tblExperience)
        {
            repository.Add(tblExperience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var value = repository.GetById(id);
            repository.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id) 
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperience tblExperience)
        {
            var value = repository.GetById(tblExperience.Id);
            value.Title = tblExperience.Title;
            value.SubTitle = tblExperience.SubTitle;
            value.Description = tblExperience.Description;
            value.Date = tblExperience.Date;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}