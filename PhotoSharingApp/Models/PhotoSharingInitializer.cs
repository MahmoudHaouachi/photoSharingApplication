using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Models
{
    public class PhotoSharingInitializer: DropCreateDatabaseAlways<PhotoSharingContext> 
    {
        protected override void Seed(PhotoSharingContext context)
        {
            List<Photo> photo = new List<Photo> () ;
            Photo p = new Photo();
            p.Title = "Test Photo";
            p.Description = "This is a test";
            p.Owner = "NaokiSato";
            p.PhotoFile = getFileBytes("\\Images\\");
            p.CreatedDate = DateTime.Now;
            p.ImageMimeType = "image/jpeg";
        }
    }
}