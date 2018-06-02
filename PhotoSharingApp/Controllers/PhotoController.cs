using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharingApp.Models;
using System.Data;

namespace PhotoSharingApp.Controllers
{
    [ValueReporter]
    public class PhotoController : Controller
    {
        private IPhotoSharingContext context;
        
        public PhotoController()
        {
            context = new PhotoSharingContext();
        }

        public PhotoController(IPhotoSharingContext Context)
        {
            context = Context;
        }
        // GET: Photo
        public ActionResult Index()
        {

            return View("Index");
            //context.Photos.First<Photo>()
            // context.Photos.ToList()
        }

        public ActionResult Display(int id)
        {
            Photo p = context.FindPhotoById(id);
            if (p != null)
                return View("Display", p);
            else
                return HttpNotFound();
        }

        public ActionResult DisplayByTitle(string title)
        {
            Photo photo = context.FindPhotoByTitle(title);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Display", photo);
        }

        public ActionResult Create()
        {
            Photo photo = new Photo();
            photo.CreatedDate = DateTime.Now;
            return View("Create", photo);
        }
        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                    context.Add<Photo>(photo);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", photo);
            }
        }



        public ActionResult Delete(int id)
        {
            Photo p = context.FindPhotoById(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Delete", p);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo p = context.FindPhotoById(id);
            context.Delete<Photo>(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            Photo p = context.FindPhotoById(id);
            if (p != null)
            {

                return (new FileContentResult(p.PhotoFile, p.ImageMimeType));
            }
            else
            {
                return null;
            }
        }
        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Photo> photos = new List<Photo>();
            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = (from p in context.Photos
                          orderby p.CreatedDate descending
                          select p).Take(number).ToList();
            }
            return PartialView("_PhotoGallery", photos);
        }
    }
}