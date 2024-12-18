using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MunicipalComplaint.Models;
using MunicipalComplaint.ViewModel;
using Rotativa;

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
        public string Logout()
        {
            Session.RemoveAll();
            return "logs";
        }
        [HttpPost]
        public ActionResult Register(CustomerSignup cus)
        {
            cus.Status = "Active";
            cus.createdat = System.DateTime.Today.ToString("dd/MM/yyyy");
            Random pass = new Random();
            int Password = pass.Next(600001, 999998);
            cus.Password = Convert.ToString(Password);
            _context.customer.Add(cus);
            _context.SaveChanges();
            List<CustomerSignup> cs = _context.customer.ToList();
            //SelectList cityy = new SelectList(cs, "Username", "Email","CNIC","Contact","Status","Address", 0);
            return Json(cs);
        }

        [HttpGet]
        public ActionResult ManageEmployee()
        {
            List<CustomerSignup> li = _context.customer.Where(X => X.Type == "Employee").ToList();
            List<Province> pv = _context.province.ToList();
            List<City> cv = _context.city.ToList();
            viewModel vm = new viewModel
            {
                provinces = pv,
                signup = li,
                cities = cv


            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult FillReport(int id) {
            List<CustomerSignup> licus = _context.customer.Where(x => x.DistrictId == id && x.Type=="Employee").ToList();
            return Json(licus);
        }
        [HttpPost]
        public ActionResult ChkUpdateUser(int id)
        {
            CustomerSignup cs = _context.customer.Single(x => x.UserId == id);
            return Json(cs);
        }
        [HttpPost]
        public ActionResult UpdateUser(CustomerSignup cs)
        {
            CustomerSignup cus = _context.customer.Single(x => x.UserId == cs.UserId);
            TryUpdateModel(cus);
            _context.SaveChanges();
            return Json("done");
        }
        [HttpPost]
        public ActionResult BlockUser(int id)
        {
            CustomerSignup cus = _context.customer.Single(x => x.UserId == id);
            cus.Status = "Block";
            TryUpdateModel(cus);
            _context.SaveChanges();
            return Json("done");
        }
        [HttpPost]
        public ActionResult UnblockUser(int id)
        {
            CustomerSignup cus = _context.customer.Single(x => x.UserId == id);
            cus.Status = "Active";
            TryUpdateModel(cus);
            _context.SaveChanges();
            return Json("done");
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
                tehsiles = teh,
                ucs = uc


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
        public ActionResult Dashboard()
        {
            List<CustomerSignup> cs = _context.customer.Where(x => x.Type == "Employee").ToList();
            List<CustomerSignup> cse = _context.customer.Where(x => x.Type == "User").ToList();
            List<complains> com = _context.compalin.ToList();
            List<complains> comRe = _context.compalin.Where(x => x.Status == 1).ToList();
            ViewData["Employee"] = cs.Count().ToString();
            ViewData["Users"] = cse.Count().ToString();
            ViewData["Complaim"] = com.Count().ToString();
            ViewData["ResolveComp"] = comRe.Count().ToString();

            return View();
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
            int i = _context.SaveChanges();
            return Json("done");

        }
        [HttpPost]
        public ActionResult drop(int id)
        {
            List<City> city = _context.city.Where(x => x.ProvinceId == id).ToList();
            SelectList cityy = new SelectList(city, "DistrictId", "DistrictName", 0);


            return Json(cityy);

        }

        [HttpPost]
        public ActionResult dropUC(int id)
        {
            List<Tehsil> teh = _context.tehsil.Where(x => x.DistrictId == id).ToList();
            SelectList tehsi = new SelectList(teh, "TehsilId", "TehsilName", 0);


            return Json(tehsi);

        }
        [HttpPost]
        public ActionResult chkProForUp(int id)
        {
            Province p = _context.province.Single(x => x.ProvinceId == id);
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
        public ActionResult updateProvince(Province pro)
        {

            var upPro = _context.province.Single(m => m.ProvinceId == pro.ProvinceId);
            TryUpdateModel(upPro);
            _context.SaveChanges();
            return Json("done");
        }
        [HttpPost]

        public ActionResult DelProvince(int id)
        {
            var ProDisTehUc = from i in _context.province join j in _context.city on i.ProvinceId equals j.ProvinceId join k in _context.tehsil on j.DistrictId equals k.DistrictId join l in _context.uc on k.TehsilId equals l.TehsilId where i.ProvinceId.Equals(id) select new { mprodis = i, prodis = j, proteh = k, prouc = l };
            if (ProDisTehUc.Count() == 0)
            {
                var DisTehUc = from i in _context.province join j in _context.city on i.ProvinceId equals j.ProvinceId join k in _context.tehsil on j.DistrictId equals k.DistrictId where i.ProvinceId.Equals(id) select new { pro = i, dis = j, teh = k };

                if (DisTehUc.Count() == 0)
                {
                    var DisTeh = from i in _context.province join j in _context.city on i.ProvinceId equals j.ProvinceId  where i.ProvinceId.Equals(id) select new { mdis = i, mteh = j };
                    if (DisTeh.Count() == 0)
                    {
                        Province city = _context.province.SingleOrDefault(x => x.ProvinceId== id);
                        _context.province.Remove(city);
                    }
                    else
                    {
                        foreach (var mdata in DisTeh)
                        {
                            _context.province.Remove(mdata.mdis);
                            _context.city.Remove(mdata.mteh);

                        }
                    }

                }
                else
                {
                    foreach (var mydata in DisTehUc)
                    {
                        _context.province.Remove(mydata.pro);
                        _context.city.Remove(mydata.dis);
                        _context.tehsil.Remove(mydata.teh);
                    }
                }


               
            }
            else
            {
                foreach (var delfull in ProDisTehUc) {

                    _context.province.Remove(delfull.mprodis);
                    _context.city.Remove(delfull.prodis);
                    _context.tehsil.Remove(delfull.proteh);
                    _context.uc.Remove(delfull.prouc);
                }

            }
            _context.SaveChanges();
            return Json("done");


        }

        [HttpPost]

        public ActionResult DelDistrict(int id)
        {
            var DisTehUc = from i in _context.city join j in _context.tehsil on i.DistrictId equals j.DistrictId join k in _context.uc on j.TehsilId equals k.TehsilId where i.DistrictId.Equals(id) select new { dis = i, teh = j, ucc = k };

            if (DisTehUc.Count() == 0)
            {
                var DisTeh = from i in _context.city join j in _context.tehsil on i.DistrictId equals j.DistrictId where i.DistrictId.Equals(id) select new { mdis = i, mteh = j };
                if (DisTeh.Count() == 0)
                {
                    City city = _context.city.SingleOrDefault(x => x.DistrictId == id);
                    _context.city.Remove(city);
                }
                else
                {
                    foreach (var mdata in DisTeh)
                    {
                        _context.city.Remove(mdata.mdis);
                        _context.tehsil.Remove(mdata.mteh);

                    }
                }
            }
            else
            {
                foreach (var mydata in DisTehUc)
                {
                    _context.city.Remove(mydata.dis);
                    _context.tehsil.Remove(mydata.teh);
                    _context.uc.Remove(mydata.ucc);
                }
            }

            _context.SaveChanges();
            return Json("done");


        }

        [HttpPost]

        public ActionResult DelTehsil(int id)
        {
            var da = from i in _context.tehsil join j in _context.uc on i.TehsilId equals j.TehsilId where i.TehsilId.Equals(id) select new { a = i, b = j };
            if (da.Count() == 0)
            {
                Tehsil teh = _context.tehsil.SingleOrDefault(x => x.TehsilId == id);
                _context.tehsil.Remove(teh);

            }
            else
            {
                foreach (var a in da)
                {
                    _context.tehsil.Remove(a.a);
                    _context.uc.Remove(a.b);
                }
            }
            _context.SaveChanges();
            return Json("done");


        }

        [HttpPost]
        public ActionResult DelUc(int id)
        {
            UC ucc = _context.uc.SingleOrDefault(x => x.UcId == id);
            _context.uc.Remove(ucc);
            _context.SaveChanges();
            return Json("done");


        }
 
        public ActionResult AdminComplain()
        {
            var complaints = _context.compalin.Where(c => c.isvalid == 0).ToList();
            var district = _context.city.ToList();
            ComplaintDistrict cd = new ComplaintDistrict
            {
                allcomplaints = complaints,
                city =district
            };
            return View(cd);
        }
        [HttpPost]
        public string UpdateComplaintStatus(int statuscmp,int id)
        {
            complains complaint = _context.compalin.Single(c => c.ComplainId == id);
            complaint.isvalid = statuscmp;
            TryUpdateModel(complaint);
            _context.SaveChanges();
            return "done";
        }

        public ActionResult EmployeeManageComplaints(int? id = 0)
        {
            int id1 = Convert.ToInt32(Session["user_id"].ToString());
            var user = _context.customer.SingleOrDefault(c => c.UserId == id1);
            int distid = user.DistrictId;
            var complains = _context.compalin.Where(c => c.isvalid == 1 && c.Status == id && c.DistrictId == distid).ToList();
            return View(complains);
        }
        [HttpPost]
        public string CloseComplaint(int compid, string comment)
        {
            var complaint = _context.compalin.Single(c => c.ComplainId == compid);
            complaint.AdminMessage = comment;
            complaint.closeDate = System.DateTime.Today.ToString("dd/MM/yyyy");
            complaint.Status = 1;
            TryUpdateModel(complaint);
            _context.SaveChanges();

            return "done";
        }
        public ActionResult PendingComplaints()
        {
            var complaints = _context.compalin.Where(c => c.isvalid == 1 && c.Status == 0).ToList();
            var district = _context.city.ToList();
            ComplaintDistrict cd = new ComplaintDistrict
            {
                allcomplaints = complaints,
                city = district
            };
            return View(cd);
        }
        public ActionResult CompletedComplaints()
        {
            var complaints = _context.compalin.Where(c => c.isvalid == 1 && c.Status > 0).ToList();
            var district = _context.city.ToList();
            ComplaintDistrict cd = new ComplaintDistrict
            {
                allcomplaints = complaints,
                city = district
            };
            return View(cd);
        }

        //PDF

        public ActionResult SingleComplain(int? id = 0)
        {
            var complaint = _context.compalin.Single(c => c.ComplainId == id);
            int distid = complaint.DistrictId;
            int userid = complaint.UserId;
            var district = _context.city.SingleOrDefault(c => c.DistrictId == distid );
            var user = _context.customer.SingleOrDefault(c => c.UserId == userid);
            var feedback = _context.feedback.SingleOrDefault(f => f.complainID == id);
            SingleComplaintDetail details = new SingleComplaintDetail
            {
                complains = complaint,
                city = district,
                user = user,
                feedback =feedback
            };
            return View(details);
        }
        public ActionResult GenerateComplaintReport(int id)
        {
            var report = new ActionAsPdf("SingleComplain", new { id = id });
            return report;
        }
        public ActionResult GenerateEmployeesReport(int DistrictNames = 0)
        {
            var employees = _context.customer.Where(e => e.Type == "Employee" && e.DistrictId==DistrictNames).ToList();
            return View(employees);
        }
        public ActionResult PrintAllReport(int DistrictNames)
        {
            var report = new ActionAsPdf("GenerateEmployeesReport",new { DistrictNames=DistrictNames });
            return report;
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