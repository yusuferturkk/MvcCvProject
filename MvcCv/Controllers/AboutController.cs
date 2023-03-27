using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        
        AboutRepository repository = new AboutRepository();

        public ActionResult Index()
        {
            var value = repository.GetList();
            return View(value);
        }
    }
}