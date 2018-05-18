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
            base.Seed(context);
            List<Comment> comment = new List<Comment>();
            List<Photo> photo = new List<Photo> () ;
            //
            Photo p = new Photo();
            p.Title = "Test Photo";
            p.Description = "This is a test";
            p.Owner = "NaokiSato";
            p.PhotoFile = getFileBytes("C:\\Users\\H.Mahmoud\\Desktop\\2a info\\MiniProjetC#\\photoSharingApplication\\PhotoSharingApp\\Images\\me.jpg");
            p.CreatedDate = DateTime.Now;
            p.ImageMimeType = "image/jpeg";
            photo.Add(p);
            //
            foreach (Photo ph in photo)
            {
                context.Photos.Add(p);
            }
            context.SaveChanges();
            //
            Comment com = new Comment();
            com.PhotoID = 1;
            com.User = "NaokiSato";
            com.Subject = "Test Comment";
            com.Body = " This comment should appear in photo 1";
            comment.Add(com);
            //
            foreach (Comment c in comment)
            {
                context.Comments.Add(com);
                
            }
            context.SaveChanges();
        }

// Define getFileBytes
        byte[] getFileBytes(string image)
        {
            return System.IO.File.ReadAllBytes(image);
        }
    }
}