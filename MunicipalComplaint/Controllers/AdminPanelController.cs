using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MunicipalComplaint.Models;
using MunicipalComplaint.ViewModel;
using System.Data.Entity;

namespace MunicipalComplaint.Controllers
{
    public class AdminPanelController : Controller
    {
        MyDbContext _context = new MyDbContext();
        // GET: AdminPanel
        public ActionResult Register()
        {
            List<Province> pv = _context.province.ToList();
            List<City> cv = _context.city.ToList();
            List<CustomerSignup> sig = _context.customer.ToList();
            viewModel vm = new viewModel
            {
                provinces = pv,
                signup = sig,
                cities = cv


            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Register(CustomerSignup cus)
        {
            cus.Status = "Active";
            cus.Type = "Employee";
            cus.createdat = System.DateTime.Today.ToString("dd/MM/yyyy");
            Random pass = new Random();
            int Password = pass.Next(600001, 999998);
            cus.Password= Convert.ToString(Password);
            _context.customer.Add(cus);
            _context.SaveChanges();
            List<CustomerSignup> cs = _context.customer.ToList();
            //SelectList cityy = new SelectList(cs, "Username", "Email","CNIC","Contact","Status","Address", 0);
            return Json(cs);
        }


        [HttpGet]
        public ActionResult Area()
        {
            List<Province> pv = _context.province.ToList();
            List<City> ct = _context.city.ToList();
            List<Tehsil> teh = _context.tehsil.ToList();
            List<UC> uc = _context.uc.ToList();
            viewModel vm = new viewModel
            {
                provinces = pv,
                cities = ct,
                tehsiles=teh,
                ucs=uc
                

            };
            return View(vm);
        }
       
        [HttpPost]
            public ActionResult Area(Province province)
        {
            _context.province.Add(province);
            _context.SaveChanges();
            return Json("done");

        }
        [HttpPost]
        public ActionResult AreaDistrict(City city)
        {
            _context.city.Add(city);
            _context.SaveChanges();
            return RedirectToAction("Area");

        }
        [HttpPost]
        public ActionResult AreaTehsil(Tehsil teh)
        {
            _context.tehsil.Add(teh);
            _context.SaveChanges();
            return Json("done");

        }
        [HttpPost]
        public ActionResult AreaUC(UC ucc)
        {
            _context.uc.Add(ucc);
            int i=_context.SaveChanges();
             return Json("done");

        }
        [HttpPost]
        public ActionResult drop(int id)
        {
           List<City>  city= _context.city.Where(x => x.ProvinceId == id).ToList();
            SelectList cityy = new SelectList(city, "DistrictId", "DistrictName", 0);


            return Json(cityy);

        }

        [HttpPost]
        public ActionResult dropUC(int id)
        {
            List<Tehsil> teh = _context.tehsil.Where(x => x.DistrictId == id).ToList();
            SelectList tehsi= new SelectList(teh, "TehsilId", "TehsilName", 0);


            return Json(tehsi);

        }
        [HttpPost]
        public ActionResult chkProForUp(int id) {
            Province p = _context.province.Single(x=>x.ProvinceId==id);
            return Json(p);
        }

        [HttpPost]
        public ActionResult chkDisForUp(int id)
        {
            City p = _context.city.Single(x => x.DistrictId == id);
            return Json(p);
        }



        [HttpPost]
        public ActionResult UpdateDistrict(City ct)
        {

            var upDis = _context.city.Single(m => m.DistrictId == ct.DistrictId);
            TryUpdateModel(upDis);
            _context.SaveChanges();
            return Json("done");
        }
        [HttpPost]
        public ActionResult chkTehForUp(int id)
        {
            Tehsil p = _context.tehsil.Single(x => x.TehsilId == id);
            return Json(p);
        }
        [HttpPost]
        public ActionResult chkUcForUp(int id)
        {
            UC uc = _context.uc.Single(x => x.UcId == id);
            return Json(uc);
        }


        [HttpPost]
        public ActionResult UpdateTehsil(Tehsil teh)
        {

            var upTeh = _context.tehsil.Single(m => m.TehsilId == teh.TehsilId);
            TryUpdateModel(upTeh);
            _context.SaveChanges();
            return Json("done");
        }



        [HttpPost]
        public ActionResult UpdateUc(UC uc)
        {

            var upUc = _context.uc.Single(m => m.UcId == uc.UcId);
            TryUpdateModel(upUc);
            _context.SaveChanges();
            return Json("done");
        }
        [HttpPost]
        public ActionResult updateProvince(Province pro) {

          var upPro = _context.province.Single(m => m.ProvinceId== pro.ProvinceId);
            TryUpdateModel(upPro);
            _context.SaveChanges();
            return Json("done");
        }
        [HttpPost]

        public ActionResult DelProvince(int id) {
            Province pro = _context.province.SingleOrDefault(x=>x.ProvinceId==id);
            _context.province.Remove(pro);
            _context.SaveChanges();
                return Json("done");
          
           
        }

        [HttpPost]

        public ActionResult DelDistrict(int id)
        {
            City city= _context.city.SingleOrDefault(x => x.DistrictId == id);
            _context.city.Remove(city);
            _context.SaveChanges();
            return Json("done");


        }

        [HttpPost]

        public ActionResult DelTehsil(int id)
        {
            Tehsil teh= _context.tehsil.SingleOrDefault(x => x.TehsilId == id);
            _context.tehsil.Remove(teh);
            _context.SaveChanges();
            return Json("done");


        }

        [HttpPost]

        public ActionResult DelUc(int id)
        {
            UC ucc= _context.uc.SingleOrDefault(x => x.UcId == id);
            _context.uc.Remove(ucc);
            _context.SaveChanges();
            return Json("done");


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