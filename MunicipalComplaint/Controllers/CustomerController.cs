using MunicipalComplaint.Models;
using MunicipalComplaint.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MunicipalComplaint.Controllers
{
    public class CustomerController : Controller
    {
        MyDbContext _context = new MyDbContext();

        // GET: Customer
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact() => View();
        [HttpPost]
        public ActionResult contactUs(ContactForm form)
        {
            form.AddedOn = DateTime.Now;
            _context.ContactMessage.Add(form);
            _context.SaveChanges();
            return View("Contact");
        }
        public ActionResult Complaint() => View();
        public ActionResult ManageComplaint() => View();
        [HttpPost]
        public ActionResult AddComplaint()
        {
            return View("Complaint");
        }
        public ActionResult CustomerSignUp()
        {
            List<Province> pv = _context.province.ToList();
            viewModel vm = new viewModel
            {
                provinces = pv
            };

            return View(vm);
        }
        [HttpGet]
        public ActionResult Profile()
        {
            List<CustomerSignup> li = _context.customer.ToList();
            List<City> cli = _context.city.ToList();
            List<Province> pli = _context.province.ToList();
            viewModel vm = new viewModel
            {
                signup = li,
                cities = cli,
                provinces = pli

            };
            return View(vm);

        }
        [HttpGet]
        public ActionResult UpdatePro()
        {
            List<CustomerSignup> li = _context.customer.ToList();
            List<City> cli = _context.city.ToList();
            List<Province> pli = _context.province.ToList();
            viewModel vm = new viewModel
            {
                signup = li,
                cities = cli,
                provinces = pli

            };
            return View(vm);

        }
        [HttpPost]
        public ActionResult UpdateProfile(CustomerSignup cs)
        {

            CustomerSignup cus = _context.customer.Single(x => x.UserId == cs.UserId);
            TryUpdateModel(cus);
            _context.SaveChanges();
            return Json("Done");
        }
        [HttpPost]
        public ActionResult ChangePassword(CustomerSignup cs)
        {
            CustomerSignup cus = _context.customer.Single(x => x.UserId == cs.UserId);
            TryUpdateModel(cus);
            _context.SaveChanges();
            return Json("done");    
        }
        [HttpPost]
        public ActionResult UploadImage(CustomerSignup cs)
        {
            CustomerSignup cus = _context.customer.Single(x => x.UserId == cs.UserId);
            string filename = Path.GetFileName(cs.ImageFile.FileName);
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/" + filename));
            cs.ImageFile.SaveAs(path);
            cus.Image = filename;
            TryUpdateModel(cus);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        [HttpPost]
        public ActionResult CustomerSignUp(CustomerSignup cms)
        {
            cms.Status = "Active";
            cms.Type = "User";
            cms.createdat = System.DateTime.Today.ToString("dd/MM/yyyy");
            _context.customer.Add(cms);
            _context.SaveChanges();

            return Json("done");
        }

        [HttpPost]
        public ActionResult drop(int id)
        {
            List<City> city = _context.city.Where(x => x.ProvinceId == id).ToList();
            SelectList cityy = new SelectList(city, "DistrictId", "DistrictName", 0);
            return Json(cityy);

        }
        public ActionResult Login()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_context == null)
            {

            }
            else
            {
                _context.Dispose();
            }
        }
    }
}