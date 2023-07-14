using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            var lst = new List<department>(); 
            using(var db = new Sem3Entities1())
            {
                lst.AddRange(db.departments.ToList());
            }
            return View(lst);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(department d)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    using(var db = new Sem3Entities1())
                    {
                        db.departments.Add(new department
                        {
                            
                            department_name = d.department_name,
                            description = d.description
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
            catch(SqlException ex)
            {
                ViewBag.error = ex.Message;
                return View(d);
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            department d = null;
            if(id==0 && id == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                using (var db = new Sem3Entities1())
                {
                    d = db.departments.Where(u => u.department_id == id).First();
                }
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(d);
            }
            
            return View(d);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, department d)
        {
            try
            {
                if (id > 0)
                {
                    using (var db = new Sem3Entities1())
                    {
                        var de = db.departments.Where(u => u.department_id == id).First();
                        //d.department_id = de.department_id;
                        de.department_name = d.department_name;
                        de.description = d.description;
                        db.SaveChanges();
                        
                        return RedirectToAction("Index");

                    }
                }
                // TODO: Add update logic here
                
                
                
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                
            }
            return View(d);
        }

       

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                // TODO: Add delete logic here
                if (id > 0)
                {
                    using (var db = new Sem3Entities1())
                    {
                        var de = db.departments.Where(u => u.department_id == id).First();
                        //d.department_id = de.department_id;
                        
                        db.departments.Remove(de);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
               
            }
             return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Search(FormCollection fc)
        {
            var lst = new List<department>();
            string title = fc["table_search"];
            
            if (title.Equals(""))
            {
                return RedirectToAction("Index");
            }
            else
            {
            try
            {
                    using(var db = new Sem3Entities1())
                    {
                    lst.AddRange(db.departments.Where(u => u.department_name.Contains(title)));

                    }
                    ViewBag.search = title;
                    return View("~/Views/Department/Index.cshtml", lst);
                }
                catch(Exception ex)
                {
                    ViewBag.error = ex.Message;
                }
            }
            return View("~/Views/Department/Index.cshtml", lst);
        }
    }
}
