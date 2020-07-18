using MunicipalComplaint.Models;
using MunicipalComplaint.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult Complaint() {
            List<UC> u = _context.uc.ToList();
           
            viewModel vm = new viewModel
            {
                
               ucs=u
            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Complaint(complains comp)
        {
            UC cm = _context.uc.Single(x=>x.UcId==comp.TownId);
            Tehsil te = _context.tehsil.Single(x=>x.TehsilId==cm.TehsilId);
            comp.DistrictId = te.DistrictId;
            comp.createdat= DateTime.Now.Date.ToString();
            comp.UserId = Convert.ToInt32(Session["user_id"]);

            string fileName = Path.GetFileName(comp.ImageFile.FileName);
            string pat = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/complainImg/" + fileName));
            comp.ImageFile.SaveAs(pat);
            comp.ImagePath = fileName;
            try
            {
                _context.compalin.Add(comp);
                _context.SaveChanges();
                TempData["Success"] = "Complain Has been Register Successfully";
                return RedirectToAction("Complaint");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Error: Complain Can not Register due to Some Reason, Please Try Again";
                return View("Complaint", comp);
            }
        }
        public ActionResult ManageComplaint() {
            List<complains> com = _context.compalin.ToList();
            List<UC> u = _context.uc.ToList();
            viewModel vm = new viewModel
            {
                ucs = u,
                complaint = com
            };
            return View(vm);
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Logout()
        {
            Session.RemoveAll();
            return "logs";
        }
        [HttpPost]
        public string Login(string email,string pass)
        {
            List<CustomerSignup> a=_context.customer.Where(x =>x.Email == email && x.Password == pass).ToList();
            if(a.Count()>0)
            {
                if (a[0].Type=="User") {
                    if (a[0].Status == "Active")
                    {
                        Session["name"] = a[0].Username;
                        Session["user_type"]= a[0].Type;
                        Session["user_id"] = a[0].UserId;
                        return "user";
                    }
                    else {
                        return "block";
                    }
                }
                 else if (a[0].Type == "Admin")
                {
                    if (a[0].Status == "Active")
                    {
                        Session["name"] = a[0].Username;
                        Session["user_type"] = a[0].Type;
                        Session["user_id"] = a[0].UserId;

                        return "admin";
                    }
                    else
                    {
                        return "block";
                    }

                }
                else if (a[0].Type == "Employee")
                {
                    if (a[0].Status == "Active")
                    {
                        Session["user_type"] = a[0].Type;
                        Session["user_id"] = a[0].UserId;

                        return "emp";
                    }
                    else
                    {
                        return "block";
                    }

                }


            }
            return "error";
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