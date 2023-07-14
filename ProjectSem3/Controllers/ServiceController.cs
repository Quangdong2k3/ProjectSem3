using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            var lst = new List<service>();
            using (var db = new Sem3Entities1())
            {
                lst = db.services.ToList();
            }
            return View(lst);
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(service d)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    using (var db = new Sem3Entities1())
                    {
                        db.services.Add(new service
                        {

                            service_name = d.service_name,
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
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(d);
            }
    }

    // GET: Service/Edit/5
    public ActionResult Edit(int id)
        {
            service d = null;
            if (id == 0 && id == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                using (var db = new Sem3Entities1())
                {
                    d = db.services.Where(u => u.service_id == id).First();
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(d);
            }

            return View(d);
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, service d)
        {
            try
            {
                if (id > 0)
                {
                    using (var db = new Sem3Entities1())
                    {
                        var de = db.services.Where(u => u.service_id == id).First();
                        //d.department_id = de.department_id;
                        de.service_name = d.service_name;
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

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Service/Delete/5
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
