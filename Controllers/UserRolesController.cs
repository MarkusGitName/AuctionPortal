using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionPortal.Models;

namespace AuctionPortal.Controllers
{
    public class UserRolesController : Controller
    {
        // GET: UserRoles
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        [HttpPost]
        public ActionResult Create(AuctionPortal.Models.addUserRole model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    DataController.GrantAdminToUse(model.userId);

                    return RedirectToAction("create");
                }
                else return View("create");
            }
            catch
            {
                return View("create");
                throw new Exception();
            }


              

            
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(string id)
        {
            addUserRoleDisply mod = DataController.getUserDisply(id);
            //return View(mod);
            return Edit(mod);
           // return View(mod);
        }



        // POST: UserRoles/Edit/5
        [HttpPost]
        public ActionResult Edit(addUserRoleDisply model)
        {
            try
            {
                // TODO: Add update logic here

               //string id = model.userId;
                    DataController.GrantAdminToUse(model.userId);

                    return RedirectToAction("Index");
                
            }
            catch(Exception e)
            {
                
                return View();
            }
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(string id)
        {
            addUserRoleDisply mod = DataController.getUserDisply(id);
            //return View("Index");
            return Delete(mod);
        }

        // POST: UserRoles/Delete/5
        [HttpPost]
        public ActionResult Delete(addUserRoleDisply model)
        {
            try
            {
                // TODO: Add delete logic here
                string id = model.userId;
                DataController.revokeRole(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
