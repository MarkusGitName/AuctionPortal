using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionPortal.Controllers;

namespace AuctionPortal.Controllers
{
    public class PhotoViewsController : Controller
    {
      

        public ActionResult file(int id)
        {
            return View();
        }
       
     




        [HttpPost]
        public ActionResult file(int id,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
               try
                {

                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/PropertyPhotos"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        string Patth = "~/PropertyPhotos/" + Path.GetFileName(file.FileName);
                        DataController.insertImage(Patth, id);
                    }
                    ViewBag.Message = "File uploaded successfully.";
                }
              /*  catch(d)
                {
                    ViewBag.Message = "Data Error.";
                }*/
                catch (Exception e)
                {

                    ViewBag.Message = "Error while file uploading."+e+" e";
                }

            }
            return View();
        }

        public ActionResult LogoFile(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogoFile(int id, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Logos"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        string Patth = "~/Logos/" + Path.GetFileName(file.FileName);
                        DataController.insertLogo(Patth, id);
                    }
                    ViewBag.Message = "File uploaded successfully.";
                }
              
                catch (Exception e)
                {

                    ViewBag.Message = "Error while file uploading." + e + " e";
                }

            }
            return View();
        }
    }
}
