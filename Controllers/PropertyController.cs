using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionPortal.Models;
using AuctionPortal.Controllers;
using System.IO;

namespace AuctionPortal.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index()
        {
            return View();
        }
        // GET: Property


        // GET: Property/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        [HttpPost]
        public ActionResult Create(newAddProppertyViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                DataController.InsertProperty2(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int id)
        {
            newAddProppertyViewModel mod = DataController.getProperty(id);
            // return Edit(id, mod);
            return View(mod);
        }

        // POST: Property/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, newAddProppertyViewModel mod)
        {
            try
            {
                // TODO: Add update logic here
                DataController.editProperty(id, mod);


                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int id)
        {
            newAddProppertyViewModel mod = DataController.getProperty(id);
            //  return Delete(mod);




            return View(mod);
        }

        // POST: Property/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, newAddProppertyViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                DataController.deleteProperty(id);
                return RedirectToAction("Index");
                //return View();
            }
            catch (Exception e)
            {
                throw e;
                // return View();
            }
        }

       
    }

}
