using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LoginTemp.Controllers
{
    public class UploadfileController : Controller
    {
        // GET: Uploadfile
        public ActionResult Index()
        {
            return View();
        }

        // POST: Uploadfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase namefile)
        {
            // TODO: SIKJSJDSf
            try
            {
                if(namefile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(namefile.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    namefile.SaveAs(path);
                    ViewBag.success = "Uploaded";
                }
                else
                {
                    ViewBag.error = "You need select file";
                }
            }
            catch (Exception e)
            {
                ViewBag.error = "Error!" + e;
            }
            return View();
        }
    }
}