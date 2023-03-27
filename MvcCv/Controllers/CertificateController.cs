using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        
        CertificateRepository repository = new CertificateRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(TblCertificate tblCertificate)
        {
            repository.Add(tblCertificate);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            var value = repository.GetById(id);
            repository.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCertificate(TblCertificate tblCertificate)
        {
            var value = repository.GetById(tblCertificate.Id);
            value.Description = tblCertificate.Description;
            value.Date = tblCertificate.Date;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}