using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharingApp.Models;
namespace PhotoSharingApp.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: Photo
        public ActionResult Index()
        {
            
            return View("Index");
            //context.Photos.First<Photo>()
            // context.Photos.ToList()
        }

        public ActionResult Display (int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var p = photos.Find(photo => photo.PhotoID == id);
            if (p != null)
                return View("Display", p);
            else
                return HttpNotFound();
        }
    }
}