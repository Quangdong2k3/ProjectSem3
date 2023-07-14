using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            var lst = new List<job_title>();
            using (var db = new Sem3Entities1())
            {
                lst.AddRange(db.job_title.ToList());
            }
            return View(lst);
        }

        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(job_title d)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    using (var db = new Sem3Entities1())
                    {
                        db.job_title.Add(new job_title
                        {

                            job_title_name = d.job_title_name,
                            description = d.description,
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

        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            job_title d = null;
            if (id == 0 && id == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                using (var db = new Sem3Entities1())
                {
                    d = db.job_title.Where(u => u.job_title_id == id).First();
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(d);
            }

            return View(d);
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, job_title d)
        {
            try
            {
                if (id > 0)
                {
                    using (var db = new Sem3Entities1())
                    {
                        var de = db.job_title.Where(u => u.job_title_id == id).First();
                        //d.department_id = de.department_id;
                        de.job_title_name = d.job_title_name;
                        de.description = d.description;
                        db.SaveChanges();

                        return RedirectToAction("Index");

                    }
                }
                // TODO: Add update logic here



            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;

            }
            return View(d);
        }

        // GET: Job/Delete/5
        
        // POST: Job/Delete/5
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
                        var de = db.job_title.Where(u => u.job_title_id == id).First();
                        //d.department_id = de.department_id;

                        db.job_title.Remove(de);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;

            }
            return RedirectToAction("Index");
        }
        public ActionResult Search(FormCollection fc)
        {
            var lst = new List<job_title>();
            string title = fc["table_search"];

            if (title.Equals(""))
            {
                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    using (var db = new Sem3Entities1())
                    {
                        lst.AddRange(db.job_title.Where(u => u.job_title_name.Contains(title)));

                    }
                    ViewBag.search = title;
                    return View("~/Views/Job/Index.cshtml", lst);
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                }
            }
            return View("~/Views/Job/Index.cshtml", lst);
        }
    }
}
