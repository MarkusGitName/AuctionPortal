using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionPortal.Models;

using Microsoft.AspNet.Identity;

namespace AuctionPortal.Controllers
{
    public class AuctionHubController : Controller
    {
      
        public ActionResult AuctionLive(int id)
        {
            AuctionViewModel newAuction = new AuctionViewModel();
            newAuction.Auction = DataController.getAuction(id);
            newAuction.property = DataController.getProperty(newAuction.Auction.PropertyId);
            newAuction.user = User.Identity.Name;

            newAuction.Paths = DataController.getPaths(id.ToString());

            ViewBag.Message = "Auction Page";

            return View(newAuction);
        }




        [HttpPost]
        public ActionResult AuctionLive( AuctionViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return View(model);
            }
            catch
            {
                return View();
            }
        }
       
    }
}
