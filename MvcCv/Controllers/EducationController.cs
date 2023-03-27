using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {

        EducationRepository repository = new EducationRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation tblEducation)
        {
            repository.Add(tblEducation);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = repository.GetById(id);
            repository.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation tblEducation)
        {
            var value = repository.GetById(tblEducation.Id);
            value.Title = tblEducation.Title;
            value.SubTitle1 = tblEducation.SubTitle1;
            value.SubTitle2 = tblEducation.SubTitle2;
            value.GPA = tblEducation.GPA;
            value.Date = tblEducation.Date;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}