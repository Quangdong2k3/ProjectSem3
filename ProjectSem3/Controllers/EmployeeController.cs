using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectSem3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var lst = new  List<EmployeeModel>();
            using (var db = new Sem3Entities1())
            {
                lst = (List<EmployeeModel>)(from e in db.employees
                                       join d in db.departments on e.department_id equals d.department_id
                                       join j in db.job_title on e.job_title_id equals j.job_title_id
                                       select new EmployeeModel()
                                       {
                                        employee_name = e.employee_name,
                                        employee_id = e.employee_id,
                                        address = e.address,
                                        phone = e.phone,
                                        email = e.email ,
                                        username = e.username,
                                        password = e.password,
                                        department_name = d.department_name,
                                        job_title_name = j.job_title_name
                                        
                                       }).ToList();



            }
            return View(lst);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            DropListDepartmentJOB();



            return View();
        }
        public void DropListDepartmentJOB()
        {
            List<department> departmentModels = new List<department>(); ;
            List<job_title> job = new List<job_title>();

            using (var db = new Sem3Entities1())
            {
                job.AddRange(db.job_title.ToList());
                departmentModels.AddRange(db.departments.ToList());
            }
            SelectList sd = new SelectList(departmentModels, "department_id", "department_name");
            SelectList sj = new SelectList(job, "job_title_id", "job_title_name");
            ViewBag.job = sj;
            ViewBag.department = sd;
        }
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(employee d)
        {
           

                try
                {
                DropListDepartmentJOB();
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    using (var db = new Sem3Entities1())
                    {
                        db.employees.Add(new employee
                        {

                            employee_name = d.employee_name,
                            address = d.address,
                            phone = d.phone,
                            email = d.email,
                            department_id = d.department_id,
                            job_title_id = d.job_title_id,
                            username = d.username,
                            password = d.password,

                        

                        
                        });
                        db.SaveChanges();
                        
                    }
                    

                    return RedirectToAction("Index");
                }
                else
                {

                    return View(d);
                }

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(d);
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
