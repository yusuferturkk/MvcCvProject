using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        
        ContactRepository repository = new ContactRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
    }
}