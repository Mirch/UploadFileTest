using MVCTestApplication.MirchService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestApplication.Controllers
{
    public class UserController : Controller
    {
        private Service1Client client = new Service1Client();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var FolderPath = "~/App_Data/uploads";
                    bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                    var path = Path.Combine(Server.MapPath(FolderPath), fileName);
                    file.SaveAs(path);
                    string imageString = null;
                    Image picture = Image.FromFile(path);
                    MemoryStream ms = new MemoryStream();

                    picture.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    var imageAsByteArray = ms.ToArray();
                    imageString = Convert.ToBase64String(imageAsByteArray);
                    client.AddWithPicture(name, imageString);

                    picture.Dispose();
                    System.IO.File.Delete(path);

                } catch (Exception e)
                {
                    ViewBag.Message = "\nERROR:" + e.ToString() + "   " + e.StackTrace.ToString();
                }
            return View();
        }


    }
}