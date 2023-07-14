using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            
            
            return View();
        }

       public ActionResult Department()
        {
            if (!CheckLoginAdmin())
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index", "Department");
        }
        public ActionResult Job()
        {
            //if (!CheckLoginAdmin())
            //{
            //    return RedirectToAction("Login");
            //}
            return RedirectToAction("Index", "Job");
        }
        private bool CheckLoginAdmin()
        {
            if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void droplistRole()
        {
            var lst = new List<job_title>();
            try
            {
                using (var db = new ProjectSem3.Models.Sem3Entities1())
                {
                    lst.AddRange(db.job_title.ToList());
                }
                ViewBag.role = new SelectList(lst, "job_title_id", "job_title_name");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
        
        }
        public ActionResult Login()
        {

         
            return View();
        }
        [HttpPost]
        public ActionResult Login(EmployeeModel e)
        {
            try
            {
                EmployeeModel emp = null;
                if (ModelState.IsValid)
                {
                    using (var db = new Sem3Entities1())
                    {
                        emp = db.employees.Where(u => u.email == e.email && u.password == e.password).Select(uz => new EmployeeModel
                        {
                            employee_id = uz.employee_id,
                            employee_name = uz.employee_name
                        }).First();
                    }
                    if (emp != null)
                    {
                        Session["AdminId"] = emp.employee_id;
                        Session["AdminName"] = emp.employee_name;
                        return RedirectToAction("Index");
                    }

                    ViewBag.error = "ko co";
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            
            
            return View(e);
        }
        public ActionResult Register()
        {
            droplistRole();
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel e)
        {
            droplistRole();
            return View(e);
        }
        public ActionResult Logout()
        {
            Session.Remove("AdminId");
            return RedirectToAction("Index");
        }
        public ActionResult Employee()
        {
           
            return RedirectToAction("Index","Employee");
        }
        public ActionResult Service()
        {

            return RedirectToAction("Index", "Service");
        }

    }
}
