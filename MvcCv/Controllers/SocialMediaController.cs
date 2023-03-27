using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        
        SocialMediaRepository repository = new SocialMediaRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia socialMedia)
        {
            repository.Add(socialMedia);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = repository.GetById(id);
            value.Status = false;
            repository.Update(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia socialMedia)
        {
            var value = repository.GetById(socialMedia.Id);
            value.Name = socialMedia.Name;
            value.Link = socialMedia.Link;
            value.Icon = socialMedia.Icon;
            value.Status = true;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}