using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillsController : Controller
    {

        SkillsRepository repository = new SkillsRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkills()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkills(TblSkills tblSkills)
        {
            repository.Add(tblSkills);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkills(int id)
        {
            var value = repository.GetById(id);
            repository.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkills(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkills(TblSkills tblSkills)
        {
            var value = repository.GetById(tblSkills.Id);
            value.Skill = tblSkills.Skill;
            value.Rating = tblSkills.Rating;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}