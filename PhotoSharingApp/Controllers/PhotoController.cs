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
            
            return View(context.Photos.First<Photo>());
        }
    }
}