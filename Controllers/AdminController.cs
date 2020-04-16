using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AuctionPortal.Models;

namespace AuctionPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            ViewBag.Message = "Admin";

            DataTable PropertyTable = new DataTable();
            DataTable AuctionsTable = new DataTable();
            DataTable[] array = new DataTable[2] { PropertyTable, AuctionsTable };

            AuctionsTable = DataController.getProperty();

            return View(array);
        }
        public ActionResult AddProperty()
        {

            DataTable PropertyTable = new DataTable();
            DataTable AuctionsTable = new DataTable();

            AuctionsTable = DataController.getProperty();

            return View(AuctionsTable);


        }
        public ActionResult AddAuction(AuctionModels model)
        {

            if (ModelState.IsValid && model.PropertyId!=0)
            {
                DataController.InsertAuction(model.PropertyId,model.StartTime,model.EndTime);

                return RedirectToAction("Index", "Admin");
            }
            else return View();


        }
        public ActionResult AddingProperty(AddProppertyViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataController.InsertProperty(model.Address, model.OpeningBid, model.Description, model.Documents, model.Location);

                return RedirectToAction("Index", "Admin");
            }
            else return View();
            // If we got this far, something failed, redisplay form
        }
        public ActionResult EditProperty(AddProppertyViewModel model)
        {
          
            return View();
            // If we got this far, something failed, redisplay form
        }
        public ActionResult RemoveProperty()
        {

            return View();
            // If we got this far, something failed, redisplay form
        }

        public ActionResult EditUserRole(addUserRole model)
        {

            if (ModelState.IsValid)
            {
                DataController.GrantAdminToUse(model.userId);

                return RedirectToAction("Index", "Admin");
            }
            else return View();
           
        }

    }
}