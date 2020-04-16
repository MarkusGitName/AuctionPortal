using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionPortal.Models;

namespace AuctionPortal.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Auction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            return View();
        }
       

        // POST: Auction/Create
        [HttpPost]
        public ActionResult Create(AuctionModels model)
        {

            try
            {            
                if (ModelState.IsValid && model.PropertyId != 0 && model.EndTime != null && model.StartTime!=null)
                {
                    DataController.InsertAuction(model.PropertyId, model.StartTime, model.EndTime);
                    return RedirectToAction("Index");
                }
                else return View(model);
                    // TODO: Add insert logic here

                }
                catch(Exception e)
                {
                throw e;
                }
        }

        public ActionResult CreateFromProperty(int id)
        {
            AuctionModels model = new AuctionModels();
            model.PropertyId = id;
             return View(model);
            
        }
        [HttpPost]
        public ActionResult CreateFromProperty(int id, AuctionModels model)
        {

            try
            {
                if (true)
                {
                    DataController.InsertAuction(id, model.StartTime, model.EndTime);
                    return RedirectToAction("Index");
                }
                else return View(model);
                // TODO: Add insert logic here

            }
            catch (Exception e)
            {
                return View();
            }
        }


        // GET: Auction/Edit/5
        public ActionResult Edit(int id)
        {

            EditAuctionModel mod = DataController.getAuction(id);
            return View(mod);
        }

        // POST: Auction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditAuctionModel model)
        {
            try
            {
                // TODO: Add update logic here
                DataController.editAuction(id, model);



                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Auction/Delete/5
        public ActionResult Delete(int id)
        {
            EditAuctionModel mod = DataController.getAuction(id);
            return View(mod);
        }

        // POST: Auction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EditAuctionModel model)
        {
            try
            {
                // TODO: Add update logic here
                DataController.deleteAuction(id);



                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
