using MvcCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        DbCvEntities db = new DbCvEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialSocialMedia()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var value = db.TblAbout.FirstOrDefault();
            return PartialView(value);
        }

        public PartialViewResult PartialExperience()
        {
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialEducation()
        {
            var values = db.TblEducation.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkills()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialInterests()
        {
            var values = db.TblInterests.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCertificate()
        {
            var values = db.TblCertificate.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialContact(TblContact tblContact)
        {
            tblContact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(tblContact);
            db.SaveChanges();
            return PartialView();
        }
    }
}