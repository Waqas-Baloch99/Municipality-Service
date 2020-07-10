using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MunicipalComplaint.Models;
using MunicipalComplaint.ViewModal;
using System.ComponentModel.DataAnnotations;

namespace MunicipalComplaint.Controllers
{
    public class AdminPanelController : Controller
    {
       
        // GET: AdminPanel
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Area()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Area(Province pv)
        {
            return RedirectToAction("Area");
        }

    }
}